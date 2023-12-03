using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Monito.Domain.Entities;
using Monito.Domain.Entities.Validations;
using Monito.Domain.Interfaces.Repositories;
using Monito.Infrastructure.Data;
using Monito.Infrastructure.Repositories;

var connectionString = "Server=(localdb)\\mssqllocaldb;Database=MonitoDb_Test;Trusted_Connection=True;";

var serviceProvider = new ServiceCollection()
	.AddDbContext<MonitoDbContext>(options =>
		options.UseSqlServer(connectionString))
	.AddTransient<IProductRepository, ProductRepository>()
	.AddTransient<ProductValidator>()
	.BuildServiceProvider();


var prodRepository = serviceProvider.GetService<IProductRepository>();


var prod = new Product() { Name = "Albicocche", Code = "" };

await prodRepository.AddAsync(prod);

var validator = serviceProvider.GetRequiredService<ProductValidator>();
var validatorResult = validator.Validate(prod);

if (validatorResult.IsValid)
{
	Console.WriteLine("Valid");
}
else
{
	Console.WriteLine("Invalid");
	foreach (var error in validatorResult.Errors)
	{
		Console.WriteLine($"{error.PropertyName}: {error.ErrorMessage}");
	}
}


foreach (var p in prodRepository.GetAllAsync().Result)
{
	Console.WriteLine(p);
}
