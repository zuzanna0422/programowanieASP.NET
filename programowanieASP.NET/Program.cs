using programowanieASP.NET.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodanie serwisów do kontenera DI.
builder.Services.AddControllersWithViews();

// Rejestracja serwisu ITravelService i jego implementacji TravelService
builder.Services.AddSingleton<ITravelService, MemoryTravelService>();

var app = builder.Build();

// Konfiguracja potoku obs³ugi ¿¹dañ HTTP.
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
