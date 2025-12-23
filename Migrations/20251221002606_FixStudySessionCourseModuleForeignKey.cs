using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class FixStudySessionCourseModuleForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudySessions_CourseModules_CourseModuleId",
                table: "StudySessions");

            migrationBuilder.AddForeignKey(
                name: "FK_StudySessions_CourseModules_CourseModuleId",
                table: "StudySessions",
                column: "CourseModuleId",
                principalTable: "CourseModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudySessions_CourseModules_CourseModuleId",
                table: "StudySessions");

            migrationBuilder.AddForeignKey(
                name: "FK_StudySessions_CourseModules_CourseModuleId",
                table: "StudySessions",
                column: "CourseModuleId",
                principalTable: "CourseModules",
                principalColumn: "Id");
        }
    }
}
