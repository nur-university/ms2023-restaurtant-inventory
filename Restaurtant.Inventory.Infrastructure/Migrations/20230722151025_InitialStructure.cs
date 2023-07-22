using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurtant.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "transaccion",
                columns: table => new
                {
                    transactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaccion", x => x.transactionId);
                });

            migrationBuilder.CreateTable(
                name: "transaccionItem",
                columns: table => new
                {
                    transactionItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    itemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    costoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaccionItem", x => x.transactionItemId);
                    table.ForeignKey(
                        name: "FK_transaccionItem_item_itemId",
                        column: x => x.itemId,
                        principalTable: "item",
                        principalColumn: "itemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaccionItem_transaccion_transactionId",
                        column: x => x.transactionId,
                        principalTable: "transaccion",
                        principalColumn: "transactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaccionItem_itemId",
                table: "transaccionItem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_transaccionItem_transactionId",
                table: "transaccionItem",
                column: "transactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaccionItem");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "transaccion");
        }
    }
}
