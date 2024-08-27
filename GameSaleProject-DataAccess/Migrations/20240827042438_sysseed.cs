using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sysseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SystemMemory",
                table: "SystemRequirements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Storage",
                table: "SystemRequirements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2762));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.InsertData(
                table: "SystemRequirements",
                columns: new[] { "Id", "CreatedDate", "GameId", "Graphics", "IsDeleted", "OS", "Storage", "SystemMemory", "SystemProcessor" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2835), 2, "NVIDIA GTX 660 2GB", false, "Windows 10", "72 GB", "8 GB", "Intel Core i5-3470" },
                    { 2, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2837), 3, "NVIDIA GTX 1060 6GB", false, "Windows 10", "70 GB", "12 GB", "Intel Core i7-4790" },
                    { 3, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2839), 4, "NVIDIA GTX 770 2GB", false, "Windows 10", "150 GB", "8 GB", "Intel Core i5-2500K" },
                    { 4, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2841), 5, "Intel HD Graphics 4000", false, "Windows 10", "12 GB", "4 GB", "Intel Core i3-3225" },
                    { 5, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2843), 6, "AMD Radeon HD 6870", false, "Windows 7", "8 GB", "8 GB", "Intel Core i5-2500" },
                    { 6, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2844), 7, "Intel HD Graphics 4000", false, "Windows 10", "1 GB", "4 GB", "Intel Core i3-3210" },
                    { 7, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2846), 8, "Intel HD Graphics 620", false, "Windows 10", "20 GB", "8 GB", "Intel Core i5-7300U" },
                    { 8, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2848), 9, "Intel HD Graphics 3000", false, "Windows 7", "500 MB", "2 GB", "Intel Core i3-2100" },
                    { 9, new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2913), 10, "NVIDIA GTX 1080 8GB", false, "Windows 10", "100 GB", "16 GB", "Intel Core i7-6700K" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<byte>(
                name: "SystemMemory",
                table: "SystemRequirements",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Storage",
                table: "SystemRequirements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
