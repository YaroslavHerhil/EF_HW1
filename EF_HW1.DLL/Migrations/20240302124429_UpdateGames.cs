using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_HW1.DLL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGoalPlayer_Team_TeamID",
                table: "GameGoalPlayer");

            migrationBuilder.DropIndex(
                name: "IX_GameGoalPlayer_TeamID",
                table: "GameGoalPlayer");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "GameGoalPlayer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "GameGoalPlayer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameGoalPlayer_TeamID",
                table: "GameGoalPlayer",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGoalPlayer_Team_TeamID",
                table: "GameGoalPlayer",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID");
        }
    }
}
