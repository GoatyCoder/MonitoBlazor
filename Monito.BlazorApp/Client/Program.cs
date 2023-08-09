using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Monito.BlazorApp.Client;
using Monito.BlazorApp.Client.Services;
using Monito.BlazorApp.Client.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Monito.BlazorApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Monito.BlazorApp.ServerAPI"));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IVarietyService, VarietyService>();

await builder.Build().RunAsync();
