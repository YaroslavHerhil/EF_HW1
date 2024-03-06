using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_HW1.DLL.Migrations
{
    /// <inheritdoc />
    public partial class PlayerGameUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => new { x.PlayerID, x.GameID });
                    table.ForeignKey(
                        name: "FK_PlayerGame_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_GameID",
                table: "PlayerGame",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    GameScoredID = table.Column<int>(type: "int", nullable: false),
                    PlayerGoalInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => new { x.GameScoredID, x.PlayerGoalInfoID });
                    table.ForeignKey(
                        name: "FK_GamePlayer_Game_GameScoredID",
                        column: x => x.GameScoredID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_Player_PlayerGoalInfoID",
                        column: x => x.PlayerGoalInfoID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_PlayerGoalInfoID",
                table: "GamePlayer",
                column: "PlayerGoalInfoID");
        }
    }
}
