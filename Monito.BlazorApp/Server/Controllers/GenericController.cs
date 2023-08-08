using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenericController<TEntity> : ControllerBase
		where TEntity : EntityBase
	{
		protected readonly IGenericRepository<TEntity> _repository;

		public GenericController(IGenericRepository<TEntity> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
		{
			var entities = await _repository.GetAllAsync();
			return Ok(entities);
		}

		[HttpGet("{id}")]
		public virtual async Task<ActionResult<TEntity>> GetById(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				return NotFound();
			}
			return Ok(entity);
		}

		[HttpPost]
		public virtual async Task<ActionResult<TEntity>> Create(TEntity entity)
		{
			await _repository.AddAsync(entity);
			return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
		}

		[HttpPut("{id}")]
		public virtual async Task<IActionResult> Update(int id, TEntity entity)
		{
			if (id != entity.Id)
			{
				return BadRequest();
			}
			await _repository.UpdateAsync(entity);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public virtual async Task<IActionResult> Delete(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				return NotFound();
			}
			await _repository.DeleteAsync(entity);
			return NoContent();
		}
	}
}
