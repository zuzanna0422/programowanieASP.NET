using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TravelEntity> Travel { get; set; } 
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelEntity>().HasData(
                new TravelEntity()
                {
                    Id = 1,
                    Nazwa = "wycieczka ",
                    DataRozpoczecia = new DateTime(2024, 12, 5),
                    DataZakonczenia = new DateTime(2024, 12, 10),
                    MiejscePoczatkowe = "Krakow",
                    MiejsceKoncowe = "Łódź",
                    Uczestnicy = ["Ola", "Ala"],
                    Przewodnik = "Alek",
                },
                new TravelEntity()
                {
                     Id = 2,
                     Nazwa = "wycieczka ",
                     DataRozpoczecia = new DateTime(2024, 12, 5),
                     DataZakonczenia = new DateTime(2024, 12, 10),
                     MiejscePoczatkowe = "Krakow",
                     MiejsceKoncowe = "Łódź",
                     Uczestnicy = ["Ola", "Ala"],
                     Przewodnik = "Alek",
                }
            );
        }

    }
}
