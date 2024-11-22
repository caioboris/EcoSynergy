using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDadosSensor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosSensor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosSensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeSensor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProducaoEnergiaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorLuminosidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosSensor_ProducoesEnergia_ProducaoEnergiaId",
                        column: x => x.ProducaoEnergiaId,
                        principalTable: "ProducoesEnergia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosSensor_ProducaoEnergiaId",
                table: "DadosSensor",
                column: "ProducaoEnergiaId",
                unique: true);
        }
    }
}
