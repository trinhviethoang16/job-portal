using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addGermanyCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "0ab30355-8edc-4675-8f07-690868f27519");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "e672db49-4e13-457f-8fcc-7c48c3a6f378");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "ed8ef825-7b3c-40cd-8b6c-618e19b037a5");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "bebbd1ca-33bd-4e51-bd45-3b7026778d61", new DateTime(2023, 6, 30, 20, 1, 41, 326, DateTimeKind.Local).AddTicks(534), "AQAAAAEAACcQAAAAEC9ppnt3Kfvadwkwrc6YZa1Ao+V+BAWpF3OPrH89+TnnGIfDi7t533H6+7JB0rgn6A==" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[] { 16, "Germany.png", "Germany" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "1d302a0a-06ee-44ee-b27f-4d2d7fbf3ba7");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "276b28b3-4fe2-4f3b-908d-df32276fca6b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "5db2ed9c-9ca2-4de5-9ce3-ec9a06c68efb");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "5658ea92-f6a5-4af1-95bf-3e1e0797a8e4", new DateTime(2023, 6, 30, 17, 47, 17, 698, DateTimeKind.Local).AddTicks(2138), "AQAAAAEAACcQAAAAEF5OVTAKWB1Igx3JcLlJWhDIK2MrXp8wTycVy47zZ0Jj/p6xX65alXx9N2R2wlkkNQ==" });
        }
    }
}
