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
