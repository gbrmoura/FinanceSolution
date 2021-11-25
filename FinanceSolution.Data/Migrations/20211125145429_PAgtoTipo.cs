using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceSolution.Data.Migrations
{
    public partial class PAgtoTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "MetodoPagamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "MetodoPagamento");
        }
    }
}
