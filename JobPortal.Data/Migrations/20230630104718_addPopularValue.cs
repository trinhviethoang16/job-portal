using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addPopularValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Popular",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popular",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popular",
                table: "Provinces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Popular",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popular",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Popular",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popular",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "Popular",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Popular",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Popular",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Popular",
                table: "AppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Popular",
                table: "Jobs",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "b91c6dc3-5574-4eb4-82d6-608682835c97");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "ea88e712-79d3-451e-982e-5cdabaaa1b40");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "ca517fe5-70f0-4e55-99ce-e49ce4bf5afb");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "1a7c2cf7-9def-45bf-9cc6-1546c2d2e79c", new DateTime(2023, 6, 30, 15, 13, 2, 874, DateTimeKind.Local).AddTicks(2791), "AQAAAAEAACcQAAAAEB2W7Fao5HCs9XH7LJknSqx19EDlYosYrXJIAF2+HsXb/eKwhpoTu8dEzABQAXsOwQ==" });
        }
    }
}
