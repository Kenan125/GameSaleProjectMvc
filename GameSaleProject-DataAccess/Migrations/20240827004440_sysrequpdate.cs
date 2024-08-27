using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sysrequpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2360));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 3, 44, 39, 324, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.CreateIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements",
                column: "GameId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 25, 23, 50, 27, 470, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.CreateIndex(
                name: "IX_SystemRequirements_GameId",
                table: "SystemRequirements",
                column: "GameId");
        }
    }
}
