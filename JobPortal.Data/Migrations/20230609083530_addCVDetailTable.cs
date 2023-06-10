using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addCVDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CVs_CVId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CVId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "CVDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVDetails_CVs_CVId",
                        column: x => x.CVId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CVDetails_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "9478085f-e470-4c31-8fbc-7ece36b2a597");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "5c6cebdc-d9c1-4218-a744-963bf0173ef7");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "41b0511e-0799-4dc2-8fbf-8ffc1be3416f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a1de77b-065a-4d59-92c0-36ca379d25f2", "AQAAAAEAACcQAAAAEPgkpz7Dx8c/loOGGBq2g6svLycZeX9IVTgmVrXKOrxGXw7Pj8huYRg6SLCkbTwACg==" });

            migrationBuilder.CreateIndex(
                name: "IX_CVDetails_CVId",
                table: "CVDetails",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVDetails_SkillId",
                table: "CVDetails",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVDetails");

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Skills",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CVId",
                table: "Skills",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CVs_CVId",
                table: "Skills",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
