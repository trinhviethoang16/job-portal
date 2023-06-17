using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Times");

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Titles",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Times",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Skills",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Provinces",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "MinSalary",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxSalary",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Categories",
                type: "bit",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AppUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9d650661-a99c-4816-af0e-911c803578fb");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "b34ae516-a1cf-496e-a5fa-0350d2e7edff");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "303774bd-b4ae-4bbb-9c48-3aa73507df5a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "95b5f6cf-18d4-4968-8d28-9b0a9396bec0", "AQAAAAEAACcQAAAAEIX80JMyL0VDPO5SkXXBPocEEe7I3jM3lYVLhVEIXpIVbI+5Wv3hhFN0GPho4Rq9oQ==", -1 });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "Disable", "Name", "Slug" },
                values: new object[] { 4, null, "At office", "at-office" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Times",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinSalary",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaxSalary",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AppUsers",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b540e89e-6ed5-4cdf-b370-7563b1295d10");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "67da6110-1549-4901-8874-3b0942ec264c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "8e5ccc04-e406-4c27-a632-a8224d492de2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "260b0371-ee1f-431a-9e1e-10563b2d48ea", "AQAAAAEAACcQAAAAEM/8IGGL14iOgloFyQIQI98rw+9XL0oHAwT1m1cg+6MEMLRWILBwFXEGvXj5GIH5+w==", null });
        }
    }
}
