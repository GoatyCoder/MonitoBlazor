using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Monito.Domain.Entities;
using Monito.Domain.Entities.Validations;
using Monito.Domain.Interfaces.Repositories;
using Monito.Infrastructure.Data;
using Monito.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MonitoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MonitoDbConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductValidator>();
builder.Services.AddScoped<IVarietyRepository, VarietyRepository>();
builder.Services.AddScoped<VarietyValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
