using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class addSkillsForJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Skills_SkillId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_SkillId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "JobSkill",
                columns: table => new
                {
                    JobsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkill", x => new { x.JobsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_JobSkill_Jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "514203ed-a089-4504-a8c7-f37d19b8918c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "a18762bc-83e3-4c5b-af20-da0530909bf6");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "ffc20b6f-34e2-43d4-a605-5500e320479e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "d0b08698-48f9-4206-8cfb-77c3c5e40aa5", new DateTime(2023, 7, 4, 18, 10, 42, 598, DateTimeKind.Local).AddTicks(8131), "AQAAAAEAACcQAAAAEOK3O9Y7/gwlyyPPjxrUp6kZ+w8IFr+Ma1qKy3cIiZKsoZ20XGXkIrMGbMWRyvGG+g==" });

            migrationBuilder.CreateIndex(
                name: "IX_JobSkill_SkillsId",
                table: "JobSkill",
                column: "SkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSkill");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "90f962a1-2886-4837-9d6c-2d5af2fa5328");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "f4bcae36-3244-4b62-8cae-163f69ac8996");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "4769f83e-1356-4c37-9c87-34f1635e7bf2");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "77a8efa9-08ca-473a-8271-cfc4b4e0dcc6", new DateTime(2023, 6, 30, 21, 5, 5, 256, DateTimeKind.Local).AddTicks(747), "AQAAAAEAACcQAAAAEAw5tfyWUYlOitoYBXrMllmnlWLYOQ5ysa4g0ejJvgSB0efR01d3QsHf0xUgTVGTVA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_SkillId",
                table: "Jobs",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Skills_SkillId",
                table: "Jobs",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
