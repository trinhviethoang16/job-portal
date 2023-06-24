using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class updateConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Titles_TitleId",
                table: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_CVs_TitleId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "AppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

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
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9e5d4b3f-53d1-42b2-b1d4-c36bae11510b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "1442cddf-8dda-46af-85d7-e847d6e9545f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "73e13b94-2cf3-4d01-b469-70415434653e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UrlAvatar" },
                values: new object[] { "e7eb4825-ce8b-428b-8eea-f386888bcd6c", "AQAAAAEAACcQAAAAELtVYEzIoESVQ/Rj5kYNak7wgKGUAVT6GWIrdOhQJP+N3g/QagkX7lz7WBzq4PUxAw==", "default_admin.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "CVs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrlAvatar",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "default_user.png");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "01b1300c-959e-43cc-b497-077ea2f9bee6");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "61d24ff4-7906-4b8e-81db-f03e7ded2519");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "e1fe9222-7180-42f5-90a5-4010998bb526");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UrlAvatar" },
                values: new object[] { "97e178f6-9ab3-4e5d-86d9-8fdcf17f5e9e", "AQAAAAEAACcQAAAAEC/HSQksL6hS91RuGmsuHhytjL54z5WF3tkgW6RBQWEZo9XL8OMlIWzd+bWwTMNwSw==", null });

            migrationBuilder.CreateIndex(
                name: "IX_CVs_TitleId",
                table: "CVs",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Titles_TitleId",
                table: "CVs",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
