using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroDePedidos.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuplidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    Inventario = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 1, 20f, "Pepsi", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 2, 15f, "Kola Real", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 3, 20f, "Pastelito", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 4, 25f, "Chokies", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 5, 30f, "Jugo Petit", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 6, 25f, "Café", 100f });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 7, 10f, "Pan", 100f });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 1, "Anneury Andrés Sosa Abreu" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 2, "Monserrat Blasco" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 3, "Guillem Moron" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 4, "Carme Aznar" });

            migrationBuilder.InsertData(
                table: "Suplidores",
                columns: new[] { "SuplidorId", "Nombres" },
                values: new object[] { 5, "Andrea Costas" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenId",
                table: "OrdenesDetalle",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ProductoId",
                table: "OrdenesDetalle",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
