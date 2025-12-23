using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaybackPositionForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaybackPositions_CourseModules_ModuleId",
                table: "PlaybackPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaybackPositions_CourseModules_ModuleId",
                table: "PlaybackPositions",
                column: "ModuleId",
                principalTable: "CourseModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaybackPositions_CourseModules_ModuleId",
                table: "PlaybackPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaybackPositions_CourseModules_ModuleId",
                table: "PlaybackPositions",
                column: "ModuleId",
                principalTable: "CourseModules",
                principalColumn: "Id");
        }
    }
}
