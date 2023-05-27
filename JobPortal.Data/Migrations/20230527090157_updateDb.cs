using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Data.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Jobs_JobId",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Workplace",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "UserAge",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "CVs");

            migrationBuilder.DropColumn(
                name: "UserPhone",
                table: "CVs");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Provinces",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Provinces_JobId",
                table: "Provinces",
                newName: "IX_Provinces_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Titles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
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
                value: "084c8f1b-86dc-4842-a0e8-251458a6b86b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "4c93edbd-add4-4f15-ae4e-21cf4d2cea8b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "e85c6396-b5d6-433f-9421-7e6fa81381a4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ca522ba-d333-46dd-bc08-bdd601e57f56", "AQAAAAEAACcQAAAAEM/VqxsqYYROUBvxeLh2WkyrjCPm1fgm/raucBBeocXFp3cOWS480BpTfKNCHToy0g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Titles_CategoryId",
                table: "Titles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CategoryId",
                table: "AppUsers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_JobId",
                table: "JobSkills",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Categories_CategoryId",
                table: "AppUsers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Categories_CategoryId",
                table: "Provinces",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                table: "Skills",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Categories_CategoryId",
                table: "Titles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Categories_CategoryId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Provinces_Categories_CategoryId",
                table: "Provinces");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Categories_CategoryId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Categories_CategoryId",
                table: "Titles");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropIndex(
                name: "IX_Titles_CategoryId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CategoryId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Provinces",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Provinces_CategoryId",
                table: "Provinces",
                newName: "IX_Provinces_JobId");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleName",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Workplace",
                table: "Jobs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleName",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAge",
                table: "CVs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhone",
                table: "CVs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ee8794d8-ed4a-4b91-849a-70827cb829e1");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "590e5fa3-577d-4af9-b3da-56bb4afee345");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "646c5491-aced-48cb-bb9b-12dc631c4f6e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "855c9200-d899-4ec6-932d-da372151de60", "AQAAAAEAACcQAAAAEKcQprb/RCRYsHlRktk1CgKNFrcEWy39u8PYshBkMfu0imzy1684fr+xAoib7OxhNA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Provinces_Jobs_JobId",
                table: "Provinces",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
