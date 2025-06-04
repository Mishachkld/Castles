using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

builder.Services.AddAntDesign();

builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri(apiBaseUrl) 
    });
await builder.Build().RunAsync();