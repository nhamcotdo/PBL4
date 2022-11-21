using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL4.Migrations
{
    public partial class updateSessionRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4Sessions_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes");

            migrationBuilder.DropForeignKey(
                name: "FK_PBL4Sessions_PBL4Classes_ClassId",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_PBL4Sessions_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.DropIndex(
                name: "IX_PBL4Sessions_ClassId",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.DropIndex(
                name: "IX_PBL4Sessions_LessonId",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.DropColumn(
                name: "ClassId",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.DropColumn(
                name: "LessonId",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "classes",
                table: "PBL4Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PBL4SessionRegisters_ClassId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PBL4SessionRegisters_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4SessionRegisters_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes",
                column: "SessionId",
                principalSchema: "classes",
                principalTable: "PBL4SessionRegisters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Classes_ClassId",
                schema: "classes",
                table: "PBL4SessionRegisters",
                column: "ClassId",
                principalSchema: "classes",
                principalTable: "PBL4Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4SessionRegisters_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes");

            migrationBuilder.DropForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Classes_ClassId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_PBL4SessionRegisters_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.DropIndex(
                name: "IX_PBL4SessionRegisters_ClassId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.DropIndex(
                name: "IX_PBL4SessionRegisters_LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "classes",
                table: "PBL4Sessions");

            migrationBuilder.DropColumn(
                name: "ClassId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.DropColumn(
                name: "LessonId",
                schema: "classes",
                table: "PBL4SessionRegisters");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassId",
                schema: "classes",
                table: "PBL4Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                schema: "classes",
                table: "PBL4Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PBL4Sessions_ClassId",
                schema: "classes",
                table: "PBL4Sessions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PBL4Sessions_LessonId",
                schema: "classes",
                table: "PBL4Sessions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4Sessions_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes",
                column: "SessionId",
                principalSchema: "classes",
                principalTable: "PBL4Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4Sessions_PBL4Classes_ClassId",
                schema: "classes",
                table: "PBL4Sessions",
                column: "ClassId",
                principalSchema: "classes",
                principalTable: "PBL4Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4Sessions_PBL4Lessons_LessonId",
                schema: "classes",
                table: "PBL4Sessions",
                column: "LessonId",
                principalSchema: "course",
                principalTable: "PBL4Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
