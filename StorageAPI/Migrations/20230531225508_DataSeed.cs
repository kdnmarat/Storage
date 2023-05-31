using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StorageAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Storages",
                table: "Products",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { 1L, 7.8m, "Apple" },
                    { 2L, 12m, "Banana" },
                    { 3L, 8.5m, "Orange" },
                    { 4L, 10m, "Brocoli" }
                });

            migrationBuilder.InsertData(
                schema: "Storages",
                table: "Storages",
                columns: new[] { "Id", "Address", "KindOfStorage", "Name" },
                values: new object[,]
                {
                    { 1L, "Somewhere in Belgrade", "Fruits", "Storage1" },
                    { 2L, "Somewhere else in Belgrade", "Vegetables", "Storage2" }
                });

            migrationBuilder.InsertData(
                schema: "Storages",
                table: "StatesOfStorages",
                columns: new[] { "Id", "ProductId", "Quantity", "StorageId" },
                values: new object[,]
                {
                    { 1L, 1L, 20m, 1L },
                    { 2L, 2L, 2m, 1L },
                    { 3L, 3L, 4m, 1L },
                    { 4L, 4L, 8m, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "StatesOfStorages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "StatesOfStorages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "StatesOfStorages",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "StatesOfStorages",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "Storages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Storages",
                table: "Storages",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
