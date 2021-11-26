using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Age_Tur.Infra.Migrations
{
    public partial class CriaçãoBancodeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_previsaclima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clima = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TemperaturaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemperaturaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_previsaclima", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cidade");

            migrationBuilder.DropTable(
                name: "tb_estado");

            migrationBuilder.DropTable(
                name: "tb_previsaclima");
        }
    }
}
