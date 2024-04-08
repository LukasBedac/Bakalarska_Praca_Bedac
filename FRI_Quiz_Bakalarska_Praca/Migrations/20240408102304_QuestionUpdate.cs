using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRI_Quiz_Bakalarska_Praca.Migrations
{
    /// <inheritdoc />
    public partial class QuestionUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Shown",
                table: "Questions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shown",
                table: "Questions");
        }
    }
}
