using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Monito.Blazor.Server.Controllers;
using Monito.Domain.Entities;
using Monito.Domain.Entities.Validations;
using Monito.Infrastructure.Data;
using Monito.Infrastructure.Repositories;

namespace Monito.Test
{
    public class ProductsControllerTest
    {
        private readonly MonitoDbContext _context;
        private readonly ProductsController _productsController;
        private readonly ProductRepository _productsRepository;
        private readonly ProductValidator _productValidator;

        public ProductsControllerTest()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<MonitoDbContext>()
        .UseSqlite(connection)
        .Options;

            _context = new MonitoDbContext(options);

            _context.Database.EnsureCreated();

            _productsRepository = new ProductRepository(_context);
            _productValidator = new ProductValidator();

            _productsController = new ProductsController(_productsRepository, _productValidator);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResultWithProducts()
        {
            // Arrange
            var prod_1 = new Product() { Id = 1, Code = "P1", Name = "Prodotto 1" };
            await _productsRepository.AddAsync(prod_1);

            // Act
            var result = await _productsController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Single(products); // Verify that there is one product in the result
        }

        [Fact]
        public async Task GetAll_WhenNoProducts_ReturnsEmptyList()
        {
            // Arrange

            // Act
            var result = await _productsController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Empty(products);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOkResultWithProduct()
        {
            // Arrange
            var productId = 1;
            var prod_1 = new Product() { Id = 1, Code = "P1", Name = "Prodotto 1" };
            await _productsRepository.AddAsync(prod_1);

            // Act
            var result = await _productsController.GetById(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var product = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(productId, product.Id);
        }

        [Fact]
        public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var productId = 2;
            var prod_1 = new Product() { Id = 1, Code = "P1", Name = "Prodotto 1" };
            await _productsRepository.AddAsync(prod_1);

            // Act
            var result = await _productsController.GetById(productId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Add_ValidProduct_ReturnsCreatedAtAction()
        {
            // Arrange
            var productToAdd = new Product { Name = "New Product", Code = "NP" };

            // Act
            var result = await _productsController.Add(productToAdd);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdProduct = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal("New Product", createdProduct.Name);
        }

        [Fact]
        public async Task Add_InvalidProduct_ReturnsBadRequest()
        {
            // Arrange
            var invalidProduct = new Product { Name = null, Code = "CP" };

            // Act
            var result = await _productsController.Add(invalidProduct);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_ValidProduct_ReturnsNoContent()
        {
            // Arrange
            var productId = 1;
            var existingProduct = new Product { Id = productId, Name = "Product to Update", Code = "UP" };
            await _productsController.Add(existingProduct);

            // Act
            var productToUpdate = new Product { Id = productId, Name = "Updated Product", Code = "UPD" };
            var result = await _productsController.Update(productId, productToUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var updatedProduct = await _productsRepository.GetAsync(productId);
            Assert.Equal("Updated Product", updatedProduct.Name);
            Assert.Equal("UPD", updatedProduct.Code);
        }

        [Fact]
        public async Task Update_InvalidProduct_ReturnsBadRequest()
        {
            // Arrange
            var productId = 1;
            var existingProduct = new Product { Id = productId, Name = "Product to Update", Code = "UP" };
            await _productsController.Add(existingProduct);

            // Act
            var productToUpdate = new Product { Name = string.Empty, Code = string.Empty };
            var result = await _productsController.Update(productId, productToUpdate);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var updatedProduct = await _productsRepository.GetAsync(productId);
            Assert.Equal("Product to Update", updatedProduct.Name);
            Assert.Equal("UP", updatedProduct.Code);
        }

        [Fact]
        public async Task Delete_ValidProduct_ReturnsNoContent()
        {
            // Arrange
            var productId = 1;
            var existingProduct = new Product { Id = productId, Name = "Product 1", Code = "P1" };
            await _productsController.Add(existingProduct);

            // Act
            var result = await _productsController.Delete(productId);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var products = await _productsRepository.GetAllAsync();
            Assert.Empty(products);
        }

        [Fact]
        public async Task Delete_InvalidProduct_ReturnsNotFound()
        {
            // Arrange
            var productId = 1;
            var invalidProductId = 2;
            var existingProduct = new Product { Id = productId, Name = "Product 1", Code = "P1" };
            await _productsController.Add(existingProduct);

            // Act
            var result = await _productsController.Delete(invalidProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result);

            var products = await _productsRepository.GetAllAsync();
            Assert.NotEmpty(products);
        }
    }
}
