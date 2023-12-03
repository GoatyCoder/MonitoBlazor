using Monito.Blazor.Shared.Services.Interfaces;
using Monito.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Monito.Blazor.Shared.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _httpClient;

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/product");
		}

		public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task Add(Product product)
		{
			throw new NotImplementedException();
		}

		public Task Delete(Product product)
		{
			throw new NotImplementedException();
		}



		public Task<Product> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Variety>> GetVarietiesByProductId(int id)
		{
			throw new NotImplementedException();
		}

		public Task Update(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
