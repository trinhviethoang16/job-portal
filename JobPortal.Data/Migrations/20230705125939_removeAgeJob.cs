using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class removeAgeJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAge",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "Jobs");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MaxAge",
                table: "Jobs",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MinAge",
                table: "Jobs",
                type: "tinyint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "514203ed-a089-4504-a8c7-f37d19b8918c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "a18762bc-83e3-4c5b-af20-da0530909bf6");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "ffc20b6f-34e2-43d4-a605-5500e320479e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "d0b08698-48f9-4206-8cfb-77c3c5e40aa5", new DateTime(2023, 7, 4, 18, 10, 42, 598, DateTimeKind.Local).AddTicks(8131), "AQAAAAEAACcQAAAAEOK3O9Y7/gwlyyPPjxrUp6kZ+w8IFr+Ma1qKy3cIiZKsoZ20XGXkIrMGbMWRyvGG+g==" });
        }
    }
}
