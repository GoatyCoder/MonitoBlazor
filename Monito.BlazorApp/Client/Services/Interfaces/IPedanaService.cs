using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
	public interface IPedanaService
	{
		Task<IEnumerable<Pedana>> GetAll();
		Task<Pedana> GetById(int id);
		Task Create(Pedana pedana);
		Task Update(Pedana pedana);
		Task Delete(int id);
	}
}
