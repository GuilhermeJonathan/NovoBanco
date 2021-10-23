using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovoBanco.Infraestrutura.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BANCOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDoCadastro",
                value: new DateTime(2021, 10, 23, 17, 2, 37, 621, DateTimeKind.Local).AddTicks(57));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BANCOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataDoCadastro",
                value: new DateTime(2021, 10, 23, 17, 1, 6, 200, DateTimeKind.Local).AddTicks(4734));
        }
    }
}
