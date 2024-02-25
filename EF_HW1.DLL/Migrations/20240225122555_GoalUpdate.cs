using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_HW1.DLL.Migrations
{
    /// <inheritdoc />
    public partial class GoalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Footballs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MissedGoals",
                table: "Footballs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Footballs");

            migrationBuilder.DropColumn(
                name: "MissedGoals",
                table: "Footballs");
        }
    }
}
