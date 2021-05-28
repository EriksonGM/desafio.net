using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioNET.Data.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPositive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionValue = table.Column<decimal>(type: "Money", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Card = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    PlaceOwner = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PlaceName = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TransactionTypeId", "IsPositive", "TypeName" },
                values: new object[,]
                {
                    { 1, true, "Débito" },
                    { 2, false, "Boleto" },
                    { 3, false, "Financiamento" },
                    { 4, true, "Crédito" },
                    { 5, true, "Recebimento Empréstimo" },
                    { 6, true, "Vendas" },
                    { 7, true, "Recebimento TED" },
                    { 8, true, "Recebimento DOC" },
                    { 9, false, "Aluguel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionTypes");
        }
    }
}
