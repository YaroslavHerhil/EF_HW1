using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_HW1.DLL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGGP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGoalPlayer");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.CreateTable(
                name: "GameGoalPlayer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGoalPlayer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameGoalPlayer_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGoalPlayer_Player_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGoalPlayer_GameID",
                table: "GameGoalPlayer",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameGoalPlayer_PlayerID",
                table: "GameGoalPlayer",
                column: "PlayerID");
        }
    }
}
