using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class updateUserConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "default_user.png");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "90c0551d-de8d-4b4b-ba09-94fe1714b5fa");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "47cb7178-edca-4234-b0a9-13d50740e98b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "4bb9e8f8-be79-4656-bfbd-655423238089");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "cc8416ee-1c55-42f0-91c5-5841014d293a", new DateTime(2023, 7, 7, 16, 19, 23, 520, DateTimeKind.Local).AddTicks(2058), "AQAAAAEAACcQAAAAEN6e72HkRA5D+BXBBSVSGdzR6hlQYsFUZEJ9enga2+8SBu+EEVjsU9/ZaRnVAqm8Ww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "default_user.png",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "3f5a2de4-fae3-4739-bad6-2239c496c6ac");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "7c0eaf12-1e0a-4eff-8988-a68ef5ecdded");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "8099f37a-37c8-48fa-8c64-e61bd2403daf");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "62b86037-b5f1-4bc8-8590-936a06c79014", new DateTime(2023, 7, 5, 19, 59, 38, 872, DateTimeKind.Local).AddTicks(2528), "AQAAAAEAACcQAAAAEOoA+SUND2adu/Luo0dlOlKR0gUJbBlBS6nY5GR0PJTNc0H46ZdStdgE6KkMdziCUA==" });
        }
    }
}
