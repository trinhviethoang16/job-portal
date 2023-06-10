using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class updateCVField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentJob",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "EndingDate",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "SkillName",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "CVs");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Major",
                table: "CVs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Introduce",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GraduatedAt",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "GPA",
                table: "CVs",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Certificate",
                table: "CVs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplyDate",
                table: "CVs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CVs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7aed2f09-7864-4b81-986d-47adc52e6da4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "924f94ea-1b5a-485d-8cd9-5b7a3e68ec1e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "028b00a9-9ee1-4896-bd9b-b78382c46048");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69517a53-2597-40b0-89c1-8ef92bf9897e", "AQAAAAEAACcQAAAAEAWn/XdUFvopOrCz6xRnKcoGLriY07IU0n+ZSpjPVS0DH8BzMXCK5yrka59vmH2m1A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyDate",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CVs");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Major",
                table: "CVs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Introduce",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GraduatedAt",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "GPA",
                table: "CVs",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Certificate",
                table: "CVs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "CurrentJob",
                table: "CVs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndingDate",
                table: "CVs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillName",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "CVs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "3d8a63a6-6ba4-43f7-894f-3f267581650d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "dcf46a0f-8f3d-4db0-8d7b-c226f5027545");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "44a18fc0-2094-4060-8d0f-fc3639adb872");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3569babb-27e4-400a-a190-4bac249dbc09", "AQAAAAEAACcQAAAAEJ3OsLWQjt26cHb+liWs45J9OYU+nMpNaMrq1R5IOic25NQ+Qlf78P+9WFSxP2C2aw==" });
        }
    }
}
