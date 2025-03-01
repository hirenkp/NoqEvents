using Events.Components;
using Events.Context;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Events.Services;
using MudBlazor;
using Microsoft.Extensions.Configuration; // Add this using statement

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Retrieve the connection string from appsettings.json as a fallback
var defaultConnectionString = builder.Configuration.GetConnectionString("Default");

// Check for the environment variable and override if present
var environmentConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

var connectionString = string.IsNullOrEmpty(environmentConnectionString) ? defaultConnectionString : environmentConnectionString;

builder.Services.AddDbContextFactory<EventsDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddMudServices(config => {
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
});

builder.Services.AddScoped<EventsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();