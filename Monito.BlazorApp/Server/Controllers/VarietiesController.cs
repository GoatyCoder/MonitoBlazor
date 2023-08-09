using Microsoft.AspNetCore.Mvc;
using Monito.Core.Entities;
using Monito.Core.Interfaces.Repositories;

namespace Monito.BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarietiesController : GenericController<Variety>
    {
        public VarietiesController(IGenericRepository<Variety> repository) : base(repository)
        {
        }
    }
}
