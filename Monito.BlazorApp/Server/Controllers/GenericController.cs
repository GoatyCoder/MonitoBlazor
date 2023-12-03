using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Monito.BlazorApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenericController<TEntity> : ControllerBase where TEntity : EntityBase
	{
		private readonly IGenericRepository<TEntity> _repository;

		public GenericController(IGenericRepository<TEntity> repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public virtual async Task<ActionResult<IEnumerable<TEntity>>> Get()
		{
			try
			{
				var entities = await _repository.GetAllAsync();
				return Ok(entities);
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante il recupero dele entità: {ex.Message}");
			}
		}

		[HttpGet("{id}")]
		public virtual async Task<ActionResult<TEntity>> Get(int id)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(id);
				if (entity == null)
				{
					return NotFound();
				}

				return Ok(entity);
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante il recupero del entità: {ex.Message}");
			}
		}

		[HttpPost]
		public virtual async Task<ActionResult<TEntity>> Create(TEntity entity)
		{
			try
			{
				await _repository.AddAsync(entity);
				return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
			}
			catch (DbUpdateException ex)
			{
				return BadRequest($"Errore durante l'aggiornamento del database: {ex.Message}");
			}
			catch (ValidationException ex)
			{
				return BadRequest($"Errore di validazione: {ex.Message}");
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante la creazione dell'entità: {ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public virtual async Task<IActionResult> Update(int id, TEntity entity)
		{
			if (id != entity.Id)
			{
				return BadRequest();
			}

			try
			{
				await _repository.UpdateAsync(entity);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante l'aggiornamento dell'entità: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public virtual async Task<IActionResult> Delete(int id)
		{
			try
			{
				var entity = await _repository.GetByIdAsync(id);
				if (entity == null)
				{
					return NotFound();
				}

				await _repository.DeleteAsync(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return BadRequest($"Errore durante l'eliminazione dell'entità: {ex.Message}");
			}
		}
	}
}
