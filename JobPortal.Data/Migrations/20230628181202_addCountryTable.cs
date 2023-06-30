using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanySize",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingDays",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disable = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "e5878d7f-0316-416a-862b-1b63c12eec94");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "5b828656-b2aa-4ece-8c8a-76e7a4fd17d8");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "728bb00d-0548-4fd1-9dbe-eaf7dbce6b13");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "bd714db8-2b28-4211-a552-273e84e20d6f", new DateTime(2023, 6, 29, 1, 12, 1, 161, DateTimeKind.Local).AddTicks(9821), "AQAAAAEAACcQAAAAEKaM3+2maDv066vnvH+TdRJFIo8NrZbzVS/6DLMV0k1ESVUhJLNzoOC07J/XgiMdzQ==" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[,]
                {
                    { 1, "Vietnam.png", "Vietnam" },
                    { 2, "USA.png", "USA" },
                    { 3, "China.png", "China" },
                    { 4, "Japan.png", "Japan" },
                    { 5, "Singapore.png", "Singapore" },
                    { 6, "Canada.png", "Canada" },
                    { 7, "England.png", "England" },
                    { 8, "India.png", "India" },
                    { 9, "Russia.png", "Russia" },
                    { 10, "Switzerland.png", "Switzerland" },
                    { 11, "France.png", "France" },
                    { 12, "Italy.png", "Italy" },
                    { 13, "Poland.png", "Poland" },
                    { 14, "Korea.png", "Korea" }
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[] { 5, "Temporary", "temporary" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CountryId",
                table: "Jobs",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Countries_CountryId",
                table: "Jobs",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Countries_CountryId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CountryId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CompanySize",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "WorkingDays",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "bd0f4cea-513b-4216-8b99-84d0d81ee5a3");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "02f0d4fe-d52c-44c3-9fc4-eca4b294da0a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "fd4f9a54-d1ee-4882-beef-efd2773760a0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "30d539d0-3b69-4e5b-8db5-abfff9723024", new DateTime(2023, 6, 28, 16, 18, 57, 772, DateTimeKind.Local).AddTicks(8436), "AQAAAAEAACcQAAAAELEo3EADuLASfpX0ZkfrgpY4a9fPTWYh6hHkKEucW/et1xMcJ0RrKlIZeusk3HvcDg==" });
        }
    }
}
