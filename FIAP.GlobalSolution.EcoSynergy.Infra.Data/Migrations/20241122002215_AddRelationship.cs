using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAP.GlobalSolution.EcoSynergy.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corrente",
                table: "ProducoesEnergia");

            migrationBuilder.DropColumn(
                name: "LocalPainel",
                table: "ProducoesEnergia");

            migrationBuilder.DropColumn(
                name: "Voltagem",
                table: "ProducoesEnergia");

            migrationBuilder.AddColumn<int>(
                name: "ProducaoEnergiaId",
                table: "DadosSensor",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paineis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProducaoMedia = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ProducaoEnergiaId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paineis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paineis_ProducoesEnergia_ProducaoEnergiaId",
                        column: x => x.ProducaoEnergiaId,
                        principalTable: "ProducoesEnergia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosSensor_ProducaoEnergiaId",
                table: "DadosSensor",
                column: "ProducaoEnergiaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paineis_ProducaoEnergiaId",
                table: "Paineis",
                column: "ProducaoEnergiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosSensor_ProducoesEnergia_ProducaoEnergiaId",
                table: "DadosSensor",
                column: "ProducaoEnergiaId",
                principalTable: "ProducoesEnergia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DadosSensor_ProducoesEnergia_ProducaoEnergiaId",
                table: "DadosSensor");

            migrationBuilder.DropTable(
                name: "Paineis");

            migrationBuilder.DropIndex(
                name: "IX_DadosSensor_ProducaoEnergiaId",
                table: "DadosSensor");

            migrationBuilder.DropColumn(
                name: "ProducaoEnergiaId",
                table: "DadosSensor");

            migrationBuilder.AddColumn<double>(
                name: "Corrente",
                table: "ProducoesEnergia",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LocalPainel",
                table: "ProducoesEnergia",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Voltagem",
                table: "ProducoesEnergia",
                type: "BINARY_DOUBLE",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
