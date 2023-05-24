using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addTimeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Times",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37caacaa-d46d-4abd-b403-d294b2be8b72", "AQAAAAEAACcQAAAAEP4CbXIfwFnF+Fj6PhCdvb01PWHXTrzxgKigJEYEto1EE5RHWAJ1ocQvxfiTbh3HKQ==" });

            migrationBuilder.UpdateData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 1,
                column: "Slug",
                value: "part-time");

            migrationBuilder.UpdateData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 2,
                column: "Slug",
                value: "full-time");

            migrationBuilder.UpdateData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Slug" },
                values: new object[] { "Work from home", "work-from-home" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Times");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "1b3ceefb-86dd-4405-87c7-06033d9c1c33");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "f0cd10a8-ecb1-456c-8703-c74a204ece8a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "5e412494-14c2-4a25-8b40-7887227c22f4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2d06abe8-c49d-40bb-8c0e-2c8e7684644b", "AQAAAAEAACcQAAAAEA/acCr/JH2uyOFD7GrPb8DW3KUwdDHcqTsCcH1mEqfsmnyB1BCYNkrCxAbIBh9WCw==" });

            migrationBuilder.UpdateData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Work form home");
        }
    }
}
