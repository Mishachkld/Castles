using AntDesign;
using Castles.Front.Client.Pages;
using Castles.Front.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddAntDesign();
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri(apiBaseUrl) 
    }); 
// Для модальных окон
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Castles.Front.Client._Imports).Assembly);

app.Run();