using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL4.Migrations
{
    public partial class AllowSessionIdNullIntableLessonComlete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4Sessions_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                schema: "course",
                table: "PBL4LessonCompletes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4Sessions_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes",
                column: "SessionId",
                principalSchema: "classes",
                principalTable: "PBL4Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4Sessions_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                schema: "course",
                table: "PBL4LessonCompletes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PBL4LessonCompletes_PBL4Sessions_SessionId",
                schema: "course",
                table: "PBL4LessonCompletes",
                column: "SessionId",
                principalSchema: "classes",
                principalTable: "PBL4Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
