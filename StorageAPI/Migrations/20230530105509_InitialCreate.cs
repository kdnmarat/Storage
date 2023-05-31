using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorageAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Storages");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Storages",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                schema: "Storages",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    KindOfStorage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatesOfStorages",
                schema: "Storages",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId1 = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    StorageId1 = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatesOfStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatesOfStorages_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalSchema: "Storages",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatesOfStorages_Storages_StorageId1",
                        column: x => x.StorageId1,
                        principalSchema: "Storages",
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatesOfStorages_ProductId1",
                schema: "Storages",
                table: "StatesOfStorages",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_StatesOfStorages_StorageId1",
                schema: "Storages",
                table: "StatesOfStorages",
                column: "StorageId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatesOfStorages",
                schema: "Storages");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Storages");

            migrationBuilder.DropTable(
                name: "Storages",
                schema: "Storages");
        }
    }
}
