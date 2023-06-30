using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class updateCountryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Countries_CountryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CountryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "af959d3c-c184-4d41-b8a3-898fc7b1116f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "3d09f178-c11b-4c03-abee-d07f22858035");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "1a7e6f0e-74a9-4fde-97c1-d0b7c55fcaa3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "2d130c4e-76d8-4c94-be63-f82e407459d9", new DateTime(2023, 6, 29, 1, 32, 15, 171, DateTimeKind.Local).AddTicks(8145), "AQAAAAEAACcQAAAAEBfTYpPVwcp1isYUhT7fJAXROpzkMEWLM2u42GTw6BQnThrguvngMK5PHQr7h4DAEw==" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CountryId",
                table: "AppUsers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Countries_CountryId",
                table: "AppUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Countries_CountryId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CountryId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "0cab3086-b800-4de8-8159-75153fce389d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "64cb0607-c61f-4cf9-abe3-1b8e93251ad0");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "0b3712ec-f50b-4f50-a557-bd926417ce01");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "bb73a130-f832-4e40-9270-a19d93f76431", new DateTime(2023, 6, 29, 1, 14, 37, 561, DateTimeKind.Local).AddTicks(9727), "AQAAAAEAACcQAAAAEI/S2wFBX3WvjH3D1pPOy2RQByTWcSIMWKiM8KsNiyfrSn+AUomP5oWT2+zkzjn/sw==" });

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
    }
}
