using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL4.Migrations
{
    public partial class allowLessonIdisNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                column: "LessonId",
                principalSchema: "course",
                principalTable: "PBL4Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                column: "LessonId",
                principalSchema: "course",
                principalTable: "PBL4Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
