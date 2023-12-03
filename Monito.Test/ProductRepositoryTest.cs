using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Monito.Domain.Entities;
using Monito.Infrastructure.Data;
using Monito.Infrastructure.Repositories;

namespace Monito.Test
{
	public class ProductRepositoryTest
	{
		private readonly MonitoDbContext _context;
		private readonly ProductRepository _repository;

		public ProductRepositoryTest()
		{
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();

			var options = new DbContextOptionsBuilder<MonitoDbContext>()
		.UseSqlite(connection)
		.Options;

			_context = new MonitoDbContext(options);

			_context.Database.EnsureCreated();

			_repository = new ProductRepository(_context);
		}

		[Fact]
		public async Task GetAllAsync_WhenNoProducts_ShouldReturnEmptyList()
		{
			var result = await _repository.GetAllAsync();
			Assert.Empty(result);
		}

		[Fact]
		public async Task AddAsync_WhenProductAdded_ShouldNotBeEmpty()
		{
			var prod = new Product() { Name = "Uva da Tavola", Code = "UVA" };

			await _repository.AddAsync(prod);

			var result = await _repository.GetAllAsync();
			Assert.NotEmpty(result);
		}

		[Fact]
		public async Task GetAsync_ShouldReturnEntityById()
		{
			await PopulateDbAsync();

			var result = await _repository.GetAsync(4);

			Assert.Equal("PES", result.Code);
		}

		[Fact]
		public async Task GetAsync_WhenNotFound_ShouldReturnNull()
		{
			await PopulateDbAsync();

			var result = await _repository.GetAsync(6);

			Assert.Null(result);
		}

		[Fact]
		public async Task GetAllAsync_ShouldReturnAllEntities()
		{
			await PopulateDbAsync();

			var result = await _repository.GetAllAsync();
			Assert.Equal(5, result.Count());
		}

		private async Task PopulateDbAsync()
		{
			var prod_1 = new Product() { Name = "Uva da Tavola", Code = "UVA" };
			var prod_2 = new Product() { Name = "Ciliegie", Code = "CIL" };
			var prod_3 = new Product() { Name = "Albicocche", Code = "ALB" };
			var prod_4 = new Product() { Name = "Pesche", Code = "PES" };
			var prod_5 = new Product() { Name = "Arance", Code = "ARA" };

			await _repository.AddAsync(prod_1);
			await _repository.AddAsync(prod_2);
			await _repository.AddAsync(prod_3);
			await _repository.AddAsync(prod_4);
			await _repository.AddAsync(prod_5);
		}

		[Fact]
		public async Task UpdateAsync_ShouldUpdateEntityInDatabase()
		{
			var product1 = new Product { Name = "Uva da Tavola", Code = "UVA" };
			await _context.Products.AddAsync(product1);

			product1.Name = "Updated Name";
			await _repository.UpdateAsync(product1);

			var result = await _repository.GetAsync(product1.Id);
			Assert.Equal("Updated Name", result.Name);
		}

		[Fact]
		public async Task DeleteAsync_ShouldRemoveEntityFromDatabase()
		{
			var product1 = new Product { Name = "Uva da Tavola", Code = "UVA" };
			await _context.Products.AddAsync(product1);

			await _repository.DeleteAsync(product1);

			var result = await _repository.GetAllAsync();
			Assert.Empty(result);
		}

		[Fact]
		public async Task AddAsync_WhenProductNameAlreadyExists_ShouldThrowException()
		{
			var product1 = new Product { Name = "Product 1", Code = "P1" };
			await _repository.AddAsync(product1);

			var product2 = new Product { Name = "Product 2", Code = "P2" };
			await Assert.ThrowsAsync<DbUpdateException>(async () => await _repository.AddAsync(product2));
		}
	}
}