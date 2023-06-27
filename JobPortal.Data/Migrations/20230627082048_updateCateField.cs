using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class updateCateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Provinces",
                type: "int",
                nullable: false,
                defaultValue: 4,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8e02199b-24dc-4739-ac2e-0e1244b22f8e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "6f819c8d-f8e3-48c0-a74d-5b01ba99a881");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "53e91e9c-49d4-4cc6-8077-e392bf175e08");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "Disable", "PasswordHash" },
                values: new object[] { "15f950d1-1f8e-4a6b-b4e0-9e1bb1b414b3", new DateTime(2023, 6, 27, 15, 20, 47, 526, DateTimeKind.Local).AddTicks(1959), false, "AQAAAAEAACcQAAAAEJob1r1U9CLm5CqTmSwbR/1tZQN+W9eH7HhLVeMkXTVJMDLB3ImLdSIbfl4qMs6PYg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Titles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Skills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Provinces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 4);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "261d4ced-a3b6-43c6-9971-d8cd1b4bf7ea");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "786a56da-960f-4709-ba94-2df5849d2b79");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "efbc77c8-13bb-48f8-987b-2a47f1ee8a8c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "Disable", "PasswordHash" },
                values: new object[] { "855b1724-a588-4834-a051-4f5d02950274", null, null, "AQAAAAEAACcQAAAAEP7353zvfb5V0idIASwPLUi8qlZDbPeZXVz0reeD5aOj9n1Far/yHT53cXzQO5W1Rg==" });
        }
    }
}
