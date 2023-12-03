using Monito.Core.Entities;

namespace Monito.BlazorApp.Client.Services.Interfaces
{
	public interface ISecondaryPackagingService
	{
		Task<IEnumerable<SecondaryPackaging>> GetPackagings();
		Task<SecondaryPackaging> GetPackaging(int id);
		Task CreatePackaging(SecondaryPackaging packaging);
		Task UpdatePackaging(SecondaryPackaging packaging);
		Task DeletePackaging(SecondaryPackaging packaging);
	}
}
