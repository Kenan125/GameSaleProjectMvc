using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameSaleProject_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(713), "High-speed racing games", false, "Racing" },
                    { 7, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(714), "Survival games with challenging gameplay", false, "Survival" },
                    { 8, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(714), "Puzzle-solving games with various challenges", false, "Puzzle" },
                    { 9, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(715), "Games set in dark, mysterious worlds", false, "Dark Fantasy" },
                    { 10, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(776), "Sci-fi games with space exploration", false, "Sci-Fi" }
                });

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
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1069));

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
                column: "CreatedDate",
                value: new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "UserId" },
                values: new object[,]
                {
                    { 9, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1018), false, "Enchanted Publishing", null },
                    { 10, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1019), false, "Heroic Media", null },
                    { 11, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1020), false, "Dark Realm Publishing", null },
                    { 12, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1020), false, "StarForge Media", null },
                    { 13, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1021), false, "Silent Shadows Inc.", null },
                    { 14, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1021), false, "Sandstorm Media", null },
                    { 15, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1022), false, "Royal Publishing", null },
                    { 16, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1023), false, "Black Flag Studios", null },
                    { 17, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1023), false, "Crawl Publishers", null },
                    { 18, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1024), false, "Urban Creations", null },
                    { 19, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1025), false, "Wild Hunt Publishing", null },
                    { 20, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1025), false, "NeoSpeed Studios", null }
                });

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

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Developer", "Discount", "GameName", "IsDeleted", "Platform", "Price", "PublisherId" },
                values: new object[,]
                {
                    { 11, 9, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "An epic journey through enchanted lands.", "Enchanted Studios", 15, "Mystic Quest", false, "PC, PS5, Xbox", 29.99m, 9 },
                    { 12, 10, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Explore the far reaches of the galaxy.", "Galaxy Games", 20, "Space Odyssey", false, "PC, Xbox", 49.99m, 12 },
                    { 13, 3, new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "A fast-paced cyberpunk adventure.", "Neon Visions", 10, "Cyber Runner", false, "PC, PS5", 39.99m, 13 },
                    { 14, 2, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uncover the secrets of lost civilizations.", "Relic Games", 25, "Ancient Ruins", false, "PC", 24.99m, 14 },
                    { 15, 3, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build and manage your own fantasy empire.", "Kingdom Creations", 30, "Fantasy Kingdom", false, "PC, PS5", 19.99m, 15 },
                    { 16, 3, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hunt down ferocious dragons in an epic RPG.", "Mythic Studios", 20, "Dragon Slayer", false, "PC, Xbox, PS5", 59.99m, 16 },
                    { 17, 6, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-speed racing across various terrains.", "Speedy Devs", 15, "Racing Thunder", false, "PC, Xbox, Switch", 34.99m, 17 },
                    { 18, 7, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Survive the zombie apocalypse.", "Apocalypse Now", 25, "Zombie Survival", false, "PC, PS5, Xbox", 14.99m, 18 },
                    { 19, 8, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solve challenging puzzles in this mind-bending game.", "Mind Games", 10, "Puzzle Master", false, "PC", 9.99m, 19 },
                    { 20, 9, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An epic RPG where you become the hero.", "Heroic Studios", 15, "Hero's Journey", false, "PC, PS5, Xbox", 44.99m, 10 }
                });

            migrationBuilder.InsertData(
                table: "SystemRequirements",
                columns: new[] { "Id", "CreatedDate", "GameId", "Graphics", "IsDeleted", "OS", "Storage", "SystemMemory", "SystemProcessor" },
                values: new object[,]
                {
                    { 10, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1147), 11, "NVIDIA GTX 1050 Ti", false, "Windows 10", "50 GB", "8 GB", "Intel i5-9600K" },
                    { 11, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1148), 12, "NVIDIA GTX 1660 Super", false, "Windows 10", "60 GB", "16 GB", "AMD Ryzen 5 3600" },
                    { 12, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1149), 13, "NVIDIA RTX 2060", false, "Windows 10", "40 GB", "8 GB", "Intel i7-10700K" },
                    { 13, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1150), 14, "NVIDIA GTX 1060", false, "Windows 10", "30 GB", "8 GB", "AMD Ryzen 3 3300X" },
                    { 14, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1151), 15, "NVIDIA GTX 1050 Ti", false, "Windows 10", "25 GB", "8 GB", "Intel i5-10400F" },
                    { 15, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1152), 16, "NVIDIA RTX 2070 Super", false, "Windows 10", "80 GB", "16 GB", "Intel i7-9700K" },
                    { 16, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1153), 17, "NVIDIA GTX 1650", false, "Windows 10", "45 GB", "8 GB", "AMD Ryzen 5 2600" },
                    { 17, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1154), 18, "NVIDIA GTX 1050", false, "Windows 10", "35 GB", "8 GB", "Intel i5-9400F" },
                    { 18, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1155), 19, "Intel UHD Graphics 630", false, "Windows 10", "20 GB", "4 GB", "Intel i3-8100" },
                    { 19, new DateTime(2024, 8, 30, 20, 35, 58, 539, DateTimeKind.Local).AddTicks(1156), 20, "NVIDIA RTX 2060 Super", false, "Windows 10", "50 GB", "16 GB", "AMD Ryzen 5 3600X" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SystemRequirements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 19);

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
    }
}
