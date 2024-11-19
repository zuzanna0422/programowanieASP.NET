using programowanieASP.NET.Models;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Data.AppDbContext>();
builder.Services.AddTransient<ITravelService, EFTravelService>();
// Dodanie serwis�w do kontenera DI.
builder.Services.AddControllersWithViews();

// Rejestracja serwisu ITravelService i jego implementacji TravelService
builder.Services.AddSingleton<ITravelService, MemoryTravelService>();

var app = builder.Build();

// Konfiguracja potoku obs�ugi ��da� HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
