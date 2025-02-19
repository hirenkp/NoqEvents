using Events.Components;
using Events.Context;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Events.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContextFactory<EventsDbContext>(options =>
{
    options.UseSqlServer(cs);
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