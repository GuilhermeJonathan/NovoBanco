using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovoBanco.Infraestrutura.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "CONTASBANCARIAS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BANCOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDoCadastro",
                value: new DateTime(2021, 10, 23, 18, 13, 55, 881, DateTimeKind.Local).AddTicks(4733));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Documento",
                table: "CONTASBANCARIAS");

            migrationBuilder.UpdateData(
                table: "BANCOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDoCadastro",
                value: new DateTime(2021, 10, 23, 17, 2, 37, 621, DateTimeKind.Local).AddTicks(57));
        }
    }
}
