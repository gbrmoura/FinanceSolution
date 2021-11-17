﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceSolution.Data.Migrations
{
    public partial class CreateV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentoTipo",
                columns: table => new
                {
                    Codigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoTipo", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamento",
                columns: table => new
                {
                    Codigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamento", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Codigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Codigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Valor = table.Column<float>(type: "float", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(240)", maxLength: 240, nullable: false),
                    LancamentoTipoCodigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    MetodoPagamentoCodigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    UsuarioCodigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Lancamento_LancamentoTipo_LancamentoTipoCodigo",
                        column: x => x.LancamentoTipoCodigo,
                        principalTable: "LancamentoTipo",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamento_MetodoPagamento_MetodoPagamentoCodigo",
                        column: x => x.MetodoPagamentoCodigo,
                        principalTable: "MetodoPagamento",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamento_Usuario_UsuarioCodigo",
                        column: x => x.UsuarioCodigo,
                        principalTable: "Usuario",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoArquivo",
                columns: table => new
                {
                    Codigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Stream = table.Column<string>(type: "text", nullable: false),
                    Extensao = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    LancamentoCodigo = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoArquivo", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_LancamentoArquivo_Lancamento_LancamentoCodigo",
                        column: x => x.LancamentoCodigo,
                        principalTable: "Lancamento",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_LancamentoTipoCodigo",
                table: "Lancamento",
                column: "LancamentoTipoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_MetodoPagamentoCodigo",
                table: "Lancamento",
                column: "MetodoPagamentoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_UsuarioCodigo",
                table: "Lancamento",
                column: "UsuarioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoArquivo_LancamentoCodigo",
                table: "LancamentoArquivo",
                column: "LancamentoCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoArquivo");

            migrationBuilder.DropTable(
                name: "Lancamento");

            migrationBuilder.DropTable(
                name: "LancamentoTipo");

            migrationBuilder.DropTable(
                name: "MetodoPagamento");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}