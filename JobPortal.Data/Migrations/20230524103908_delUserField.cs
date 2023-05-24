using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class delUserField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "18a1c891-8d0e-42a5-9cea-696c78c09f75");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "45adc1fd-ebbb-4f9f-bb8d-552982d81ff9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "31913d53-57b4-4604-be7e-97f94eaa3fb9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5fc18b3-768e-4f32-84b8-d56a7bc0bad4", "AQAAAAEAACcQAAAAEAiWmZ59sAAgmIDmXmIVrgKMpIXr2g+dyy+CvXBHXQS8xhTYiT5/dPC8QSQejGfFxw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppRoleId",
                table: "AppUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "User");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d5d02685-7009-4f3d-be88-7c35285d3888");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "fecbdc84-0fd7-4af7-85d1-1319c5bc2633");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "a65e6cbb-ddf4-4af4-a0c3-6bbd9f931513");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleName" },
                values: new object[] { "37caacaa-d46d-4abd-b403-d294b2be8b72", "AQAAAAEAACcQAAAAEP4CbXIfwFnF+Fj6PhCdvb01PWHXTrzxgKigJEYEto1EE5RHWAJ1ocQvxfiTbh3HKQ==", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
