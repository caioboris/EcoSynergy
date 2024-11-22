using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosSensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorLuminosidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    NomeSensor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosSensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducoesEnergia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PotenciaGerada = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    TemperaturaAmbiente = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Voltagem = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Corrente = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    LocalPainel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducoesEnergia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosSensor");

            migrationBuilder.DropTable(
                name: "ProducoesEnergia");
        }
    }
}
