using Microsoft.AspNetCore.Mvc;
using Monito.Domain.Entities;
using Monito.Domain.Entities.Validations;
using Monito.Domain.Interfaces.Repositories;

namespace Monito.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : GenericController<Product, IProductRepository>
    {
        private readonly IProductRepository _repository;
        private readonly ProductValidator _validator;

        public ProductsController(IProductRepository repository, ProductValidator validator) : base(repository, validator)
        {
            _repository = repository;
            _validator = validator;
        }

        // GET: api/[controller]/{id}/varieties
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{productId}/varieties")]
        public async Task<ActionResult<IEnumerable<Variety>>> GetVarieties(int productId)
        {
            try
            {
                var varieties = await _repository.GetVarieties(productId);

                if (!varieties.Any())
                {
                    return NotFound(); // Restituisce uno stato 404
                }

                return Ok(varieties);  // Restituisce uno stato 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Si è verificato un errore durante il recupero delle varietà", ExceptionMessage = ex.Message });
            }
        }
    }
}
