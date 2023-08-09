using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
    public interface IVarietyService
    {
        Task<IEnumerable<Variety>> GetAllAsync();
        Task<Variety> GetByIdAsync(int id);
        Task AddAsync(Variety entity);
        Task UpdateAsync(Variety entity);
        Task DeleteAsync(Variety entity);
    }
}
