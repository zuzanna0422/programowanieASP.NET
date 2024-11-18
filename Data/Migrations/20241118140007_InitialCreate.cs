using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Nazwa = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MiejscePoczatkowe = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MiejsceKoncowe = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Uczestnicy = table.Column<string>(type: "TEXT", nullable: false),
                    Przewodnik = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Travel",
                columns: new[] { "Id", "DataRozpoczecia", "DataZakonczenia", "MiejsceKoncowe", "MiejscePoczatkowe", "Nazwa", "Priority", "Przewodnik", "Uczestnicy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Łódź", "Krakow", "wycieczka ", 0, "Alek", "[\"Ola\",\"Ala\"]" },
                    { 2, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Łódź", "Krakow", "wycieczka ", 0, "Alek", "[\"Ola\",\"Ala\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travel");
        }
    }
}
