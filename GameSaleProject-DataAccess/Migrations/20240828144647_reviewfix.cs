using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class reviewfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6367));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 28, 17, 46, 46, 907, DateTimeKind.Local).AddTicks(6370));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2844));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 27, 7, 24, 37, 199, DateTimeKind.Local).AddTicks(2913));
        }
    }
}
