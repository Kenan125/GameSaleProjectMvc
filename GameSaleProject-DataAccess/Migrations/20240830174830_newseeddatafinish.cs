using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newseeddatafinish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4699), "Survival games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4701), "Puzzle-solving games" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4702), "First-person and third-person shooters", "Shooter" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(4703), "Sports games", "Sports" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "Developer", "GameName", "Platform", "Price" },
                values: new object[] { new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "An action-adventure game", "Santa Monica Studio", "God of War", "PS4", 49.99m });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price" },
                values: new object[] { 2, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "An open-world adventure game", "Nintendo", 0, "The Legend of Zelda: Breath of the Wild", "Switch", 59.99m });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 2, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Viking-themed action RPG", "Ubisoft Montreal", 10, "Assassin's Creed Valhalla", "PC, PS4, Xbox One", 59.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 9, new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A first-person shooter", "Infinity Ward", 20, "Call of Duty: Modern Warfare", "PC, PS4, Xbox One", 59.99m, 11 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 9, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A fast-paced first-person shooter", "id Software", 15, "DOOM Eternal", "PC, PS4, Xbox One", 49.99m, 12 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A reimagining of the classic RPG", "Square Enix", 10, "Final Fantasy VII Remake", "PS4", 59.99m, 13 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "PublisherId" },
                values: new object[] { 9, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A sci-fi first-person shooter", "343 Industries", 5, "Halo Infinite", "PC, Xbox Series X/S", 14 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 2, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "A VR action-adventure game", "Valve", 20, "Half-Life: Alyx", "PC", 59.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 3, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A turn-based RPG", "Ryu Ga Gotoku Studio", 10, "Yakuza: Like a Dragon", "PC, PS4, Xbox One", 59.99m, 16 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 1, new DateTime(2019, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "A fighting game", "NetherRealm Studios", "Mortal Kombat 11", "PC, PS4, Xbox One", 49.99m, 17 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 7, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A survival horror game", "Capcom", "Resident Evil Village", "PC, PS5, Xbox Series X/S", 59.99m, 18 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5101), "/images/godofwar.jpg", "godofwar" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "GameId", "ImageType", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5102), 11, "card", "/images/zelda.jpg", "zelda" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "GameId", "ImageType", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5103), 12, "card", "/images/assassinscreed.jpg", "assassinscreed" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "GameId", "ImageType", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5104), 13, "card", "/images/cod.jpg", "cod" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "GameId", "ImageType", "ImageUrl", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 14, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5105), 14, "card", "/images/doom.jpg", false, "doom" },
                    { 15, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5106), 15, "card", "/images/ff7.jpg", false, "ff7" },
                    { 16, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5107), 16, "card", "/images/halo.jpg", false, "halo" },
                    { 17, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5107), 17, "card", "/images/halflife.jpg", false, "halflife" },
                    { 18, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5108), 18, "card", "/images/yakuza.jpg", false, "yakuza" },
                    { 19, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5110), 19, "card", "/images/mk11.jpg", false, "mk11" },
                    { 20, new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5111), 20, "card", "/images/residentevil.jpg", false, "residentevil" }
                });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5048), "Sony Interactive Entertainment" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5049), "Nintendo" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5050), "Ubisoft" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5051), "Activision" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5051), "Bethesda Softworks" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5052), "Square Enix" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5052), "Microsoft Studios" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5053), "Valve" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5055), "SEGA" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5055), "Warner Bros. Interactive Entertainment" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5056), "Capcom" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5057), "Blizzard Entertainment" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5057), "Take-Two Interactive" });

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5183));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 48, 30, 2, DateTimeKind.Local).AddTicks(5202));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(714), "Survival games with challenging gameplay" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(714), "Puzzle-solving games with various challenges" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(715), "Games set in dark, mysterious worlds", "Dark Fantasy" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(776), "Sci-fi games with space exploration", "Sci-Fi" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "Developer", "GameName", "Platform", "Price" },
                values: new object[] { new DateTime(2016, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "A farming simulation game", "ConcernedApe", "Stardew Valley", "PC", 14.99m });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price" },
                values: new object[] { 9, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "An epic journey through enchanted lands.", "Enchanted Studios", 15, "Mystic Quest", "PC, PS5, Xbox", 29.99m });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 10, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore the far reaches of the galaxy.", "Galaxy Games", 20, "Space Odyssey", "PC, Xbox", 49.99m, 12 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 3, new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A fast-paced cyberpunk adventure.", "Neon Visions", 10, "Cyber Runner", "PC, PS5", 39.99m, 13 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uncover the secrets of lost civilizations.", "Relic Games", 25, "Ancient Ruins", "PC", 24.99m, 14 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build and manage your own fantasy empire.", "Kingdom Creations", 30, "Fantasy Kingdom", "PC, PS5", 19.99m, 15 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "PublisherId" },
                values: new object[] { 3, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunt down ferocious dragons in an epic RPG.", "Mythic Studios", 20, "Dragon Slayer", "PC, Xbox, PS5", 16 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 6, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-speed racing across various terrains.", "Speedy Devs", 15, "Racing Thunder", "PC, Xbox, Switch", 34.99m, 17 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 7, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Survive the zombie apocalypse.", "Apocalypse Now", 25, "Zombie Survival", "PC, PS5, Xbox", 14.99m, 18 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 8, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solve challenging puzzles in this mind-bending game.", "Mind Games", "Puzzle Master", "PC", 9.99m, 19 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CategoryId", "CreatedDate", "Description", "Developer", "GameName", "Platform", "Price", "PublisherId" },
                values: new object[] { 9, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An epic RPG where you become the hero.", "Heroic Studios", "Hero's Journey", "PC, PS5, Xbox", 44.99m, 10 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1067), "/images/stardewvalley.jpg", "stardewvalley" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "GameId", "ImageType", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1067), 7, "carousel", "/images/darksouls3Caus.jpg", "darksouls3Caus" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "GameId", "ImageType", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1068), 4, "carousel", "/images/rdr2Caus.jpg", "rdr2Caus" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "GameId", "ImageType", "ImageUrl", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1069), 9, "carousel", "/images/fortniteCaus.jpg", "fortniteCaus" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1018), "ConcernedApe" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1018), "Enchanted Publishing" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1019), "Heroic Media" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1020), "Dark Realm Publishing" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1020), "StarForge Media" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1021), "Silent Shadows Inc." });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1021), "Sandstorm Media" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1022), "Royal Publishing" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1023), "Black Flag Studios" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1023), "Crawl Publishers" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1024), "Urban Creations" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1025), "Wild Hunt Publishing" });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1025), "NeoSpeed Studios" });

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1156));
        }
    }
}
