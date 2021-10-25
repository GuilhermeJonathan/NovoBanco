using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovoBanco.Infraestrutura.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANCOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataDoCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANCOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CONTASBANCARIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    DataDoCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTASBANCARIAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONTASBANCARIAS_BANCOS_BancoId",
                        column: x => x.BancoId,
                        principalTable: "BANCOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BANCOS",
                columns: new[] { "Id", "Ativo", "Codigo", "DataDoCadastro", "Nome" },
                values: new object[,]
                {
                    { 1, true, "001", new DateTime(2021, 10, 25, 9, 37, 27, 239, DateTimeKind.Local).AddTicks(9653), "BANCO DO BRASIL" },
                    { 2, true, "070", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5767), "BRB" },
                    { 3, true, "104", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5811), "CAIXA ECONÔMICA FEDERAL" },
                    { 4, true, "429", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5813), "BANCO INTER" },
                    { 6, true, "237", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5814), "BRADESCO" },
                    { 7, true, "008", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5819), "SANTANDER" },
                    { 8, true, "756", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5820), "SICOOB" },
                    { 9, true, "048", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5821), "ITAU" },
                    { 10, true, "422", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5823), "SAFRA" },
                    { 11, true, "477", new DateTime(2021, 10, 25, 9, 37, 27, 240, DateTimeKind.Local).AddTicks(5825), "CITIBANK" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTASBANCARIAS_BancoId",
                table: "CONTASBANCARIAS",
                column: "BancoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTASBANCARIAS");

            migrationBuilder.DropTable(
                name: "BANCOS");
        }
    }
}
