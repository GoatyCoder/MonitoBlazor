using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
	public interface IVarietyService
	{
		Task<IEnumerable<Variety>> GetVarieties();
		Task<Variety> GetVariety(int id);
		Task CreateVariety(Variety variety);
		Task UpdateVariety(Variety variety);
		Task DeleteVariety(Variety variety);
	}
}
