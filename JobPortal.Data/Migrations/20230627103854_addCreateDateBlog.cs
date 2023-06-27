using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addCreateDateBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8379a68e-ce12-4f66-bb1f-bede7c2f9ed3");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "7d422fbc-1981-492b-b965-740cc0673c7a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "607b7643-dde6-41d4-bc09-8f2c49aa4e14");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "d41b4fe4-f3fc-4332-8363-b74e7ed97e48", new DateTime(2023, 6, 27, 17, 38, 53, 779, DateTimeKind.Local).AddTicks(906), "AQAAAAEAACcQAAAAEMDAy/hNMjGlfZR2qdyb1PAC7TizKWZS33tRetuc/ZKgTe/BQufDibPhYeOre6GV/A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Blogs");

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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "15f950d1-1f8e-4a6b-b4e0-9e1bb1b414b3", new DateTime(2023, 6, 27, 15, 20, 47, 526, DateTimeKind.Local).AddTicks(1959), "AQAAAAEAACcQAAAAEJob1r1U9CLm5CqTmSwbR/1tZQN+W9eH7HhLVeMkXTVJMDLB3ImLdSIbfl4qMs6PYg==" });
        }
    }
}
