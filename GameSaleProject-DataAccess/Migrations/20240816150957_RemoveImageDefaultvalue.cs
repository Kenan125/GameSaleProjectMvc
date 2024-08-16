using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageDefaultvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "default");

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
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6007), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6009), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6010), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6011), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6012), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6013), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6014), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6015), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6016), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6017), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6018), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6018), null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 18, 9, 56, 169, DateTimeKind.Local).AddTicks(6019), null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "default",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2224), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2226), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2227), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2228), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2229), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2230), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2231), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2232), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2233), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2234), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2235), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2236), "default" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ImageType" },
                values: new object[] { new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2237), "default" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 16, 17, 20, 3, 553, DateTimeKind.Local).AddTicks(2199));
        }
    }
}
