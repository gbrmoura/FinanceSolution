using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceSolution.Data.Migrations
{
    public partial class UserDependeci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PaymentMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AccountEntry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AccountAccruals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_UserId",
                table: "PaymentMethod",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntry_UserId",
                table: "AccountEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAccruals_UserId",
                table: "AccountAccruals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAccruals_User_UserId",
                table: "AccountAccruals",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountEntry_User_UserId",
                table: "AccountEntry",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_User_UserId",
                table: "PaymentMethod",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAccruals_User_UserId",
                table: "AccountAccruals");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountEntry_User_UserId",
                table: "AccountEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_User_UserId",
                table: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethod_UserId",
                table: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_AccountEntry_UserId",
                table: "AccountEntry");

            migrationBuilder.DropIndex(
                name: "IX_AccountAccruals_UserId",
                table: "AccountAccruals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccountEntry");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AccountAccruals");
        }
    }
}
