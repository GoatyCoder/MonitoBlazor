using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Monito.Domain.Entities;
using Monito.Domain.Interfaces.Repositories;

namespace Monito.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity, TRepository> : ControllerBase
        where TEntity : EntityBase
        where TRepository : IRepository<TEntity>

    {
        private readonly TRepository _repository;
        private readonly IValidator<TEntity> _validator;

        public GenericController(TRepository repository, IValidator<TEntity> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        // GET: api/[controller]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            try
            {
                var entities = await _repository.GetAllAsync();

                if (!entities.Any())
                {
                    return NotFound(); // Restituisce uno stato 404
                }

                return Ok(entities);  // Restituisce uno stato 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero delle entità", ExceptionMessage = ex.Message });
            }
        }

        // GET: api/[controller]/{id}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);
                if (entity == null)
                {
                    return NotFound(); // Restituisce uno stato 404
                }
                return Ok(entity); // Restituisce uno stato 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero dell'entità", ExceptionMessage = ex.Message });
            }
        }

        // POST: api/[controller]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public virtual async Task<IActionResult> Add(TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return BadRequest(new { Errors = errors });  // Restituisce uno stato 400
            }

            try
            {
                await _repository.AddAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);  // Restituisce uno stato 201
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Si è verificato un errore durante la creazione dell'entità", ExceptionMessage = ex.Message });
            }
        }

        // PUT: api/[controller]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();  // Restituisce uno stato 400
            }

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToString());  // Restituisce uno stato 400
            }

            try
            {
                var existingEntity = await _repository.GetAsync(entity.Id);
                if (existingEntity != null)
                {
                    return NotFound(); // Restituisce uno stato 404
                }

                await _repository.UpdateAsync(entity);
                return NoContent(); // Restituisce uno stato 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Si è verificato un errore durante l'aggiornamento dell'entità", ExceptionMessage = ex.Message });
            }
        }

        // DELETE: api/[controller]/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);

                if (entity is null)
                {
                    return NotFound(); // Restituisce uno stato 404
                }

                await _repository.DeleteAsync(entity);
                return NoContent(); // Restituisce uno stato 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Si è verificato un errore durante l'eliminazione dell'entità", ExceptionMessage = ex.Message });
            }
        }
    }
}
