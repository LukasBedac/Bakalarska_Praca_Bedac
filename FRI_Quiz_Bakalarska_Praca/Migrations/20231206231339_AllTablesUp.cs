using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRI_Quiz_Bakalarska_Praca.Migrations
{
    /// <inheritdoc />
    public partial class AllTablesUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Odpoved_Otazka_OtazkaId",
                table: "Odpoved");

            migrationBuilder.DropForeignKey(
                name: "FK_Otazka_Kvizy_KvizId",
                table: "Otazka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Otazka",
                table: "Otazka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Odpoved",
                table: "Odpoved");

            migrationBuilder.RenameTable(
                name: "Otazka",
                newName: "Otazky");

            migrationBuilder.RenameTable(
                name: "Odpoved",
                newName: "Odpovede");

            migrationBuilder.RenameIndex(
                name: "IX_Otazka_KvizId",
                table: "Otazky",
                newName: "IX_Otazky_KvizId");

            migrationBuilder.RenameIndex(
                name: "IX_Odpoved_OtazkaId",
                table: "Odpovede",
                newName: "IX_Odpovede_OtazkaId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Otazky",
                table: "Otazky",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Odpovede",
                table: "Odpovede",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Odpovede_Otazky_OtazkaId",
                table: "Odpovede",
                column: "OtazkaId",
                principalTable: "Otazky",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Otazky_Kvizy_KvizId",
                table: "Otazky",
                column: "KvizId",
                principalTable: "Kvizy",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Odpovede_Otazky_OtazkaId",
                table: "Odpovede");

            migrationBuilder.DropForeignKey(
                name: "FK_Otazky_Kvizy_KvizId",
                table: "Otazky");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Otazky",
                table: "Otazky");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Odpovede",
                table: "Odpovede");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Otazky",
                newName: "Otazka");

            migrationBuilder.RenameTable(
                name: "Odpovede",
                newName: "Odpoved");

            migrationBuilder.RenameIndex(
                name: "IX_Otazky_KvizId",
                table: "Otazka",
                newName: "IX_Otazka_KvizId");

            migrationBuilder.RenameIndex(
                name: "IX_Odpovede_OtazkaId",
                table: "Odpoved",
                newName: "IX_Odpoved_OtazkaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Otazka",
                table: "Otazka",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Odpoved",
                table: "Odpoved",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Odpoved_Otazka_OtazkaId",
                table: "Odpoved",
                column: "OtazkaId",
                principalTable: "Otazka",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Otazka_Kvizy_KvizId",
                table: "Otazka",
                column: "KvizId",
                principalTable: "Kvizy",
                principalColumn: "Id");
        }
    }
}
