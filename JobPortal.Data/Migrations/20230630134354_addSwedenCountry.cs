using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addSwedenCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "6d29e75d-c796-44d2-8a65-5bbd17bb6bdb");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "9b852f7d-96bf-4036-8e9c-dd3cf5089969");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "fb950e74-7cce-4734-bee8-924c518c7a19");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "8546f9f4-47e9-45a5-bfdf-489b9cc14449", new DateTime(2023, 6, 30, 20, 43, 53, 399, DateTimeKind.Local).AddTicks(9234), "AQAAAAEAACcQAAAAEFUX1zMPXUuOPVYIIUJzG/eB52dMdeX9W8r9cP7ISgb6ZcKq+oXM0HqR4WPTobJ5xg==" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Flag", "Name" },
                values: new object[] { 17, "Sweden.png", "Sweden" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 17);

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
        }
    }
}
