using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBakeryApp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroCupomFiscal",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CupomFiscalId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CupomFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupomFiscal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CupomFiscal_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CupomFiscalId",
                table: "Produtos",
                column: "CupomFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_CupomFiscal_ClienteId",
                table: "CupomFiscal",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_CupomFiscal_CupomFiscalId",
                table: "Produtos",
                column: "CupomFiscalId",
                principalTable: "CupomFiscal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_CupomFiscal_CupomFiscalId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "CupomFiscal");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CupomFiscalId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "NumeroCupomFiscal",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "CupomFiscalId",
                table: "Produtos");
        }
    }
}
