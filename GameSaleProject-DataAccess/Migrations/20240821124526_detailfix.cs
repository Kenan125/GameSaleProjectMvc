using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class detailfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRefundable",
                table: "GameSaleDetails",
                newName: "IsRefunded");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 21, 15, 45, 25, 662, DateTimeKind.Local).AddTicks(5844));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRefunded",
                table: "GameSaleDetails",
                newName: "IsRefundable");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5717));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6015));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(5983));
        }
    }
}
