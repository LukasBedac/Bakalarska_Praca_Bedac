using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRI_Quiz_Bakalarska_Praca.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Typ",
                table: "Kvizy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Kvizy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KvizId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kvizy_UserId",
                table: "Kvizy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KvizId",
                table: "AspNetUsers",
                column: "KvizId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Kvizy_KvizId",
                table: "AspNetUsers",
                column: "KvizId",
                principalTable: "Kvizy",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kvizy_AspNetUsers_UserId",
                table: "Kvizy",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Kvizy_KvizId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Kvizy_AspNetUsers_UserId",
                table: "Kvizy");

            migrationBuilder.DropIndex(
                name: "IX_Kvizy_UserId",
                table: "Kvizy");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_KvizId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Typ",
                table: "Kvizy");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Kvizy");

            migrationBuilder.DropColumn(
                name: "KvizId",
                table: "AspNetUsers");
        }
    }
}
