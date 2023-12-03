using Microsoft.AspNetCore.Mvc;
using Monito.Domain.Entities;
using Monito.Domain.Entities.Validations;
using Monito.Domain.Interfaces.Repositories;

namespace Monito.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarietiesController : GenericController<Variety, IVarietyRepository>
    {
        private readonly IVarietyRepository _repository;
        private readonly VarietyValidator _validator;

        public VarietiesController(IVarietyRepository repository, VarietyValidator validator) : base(repository, validator)
        {
            _repository = repository;
            _validator = validator;
        }
    }
}
