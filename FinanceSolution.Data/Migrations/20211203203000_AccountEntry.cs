using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FinanceSolution.Data.Migrations
{
    public partial class AccountEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<float>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountAccrualsId = table.Column<int>(type: "int", nullable: false),
                    AccountAccrualId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    AccountFileId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsModified = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountEntry_AccountAccruals_AccountAccrualId",
                        column: x => x.AccountAccrualId,
                        principalTable: "AccountAccruals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountEntry_AccountFile_AccountFileId",
                        column: x => x.AccountFileId,
                        principalTable: "AccountFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountEntry_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntry_AccountAccrualId",
                table: "AccountEntry",
                column: "AccountAccrualId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntry_AccountFileId",
                table: "AccountEntry",
                column: "AccountFileId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountEntry_PaymentMethodId",
                table: "AccountEntry",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEntry");
        }
    }
}
