using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerpusWebProject.Migrations
{
    /// <inheritdoc />
    public partial class FixPeminjamanRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peminjamans_Bukus_BukuIdBuku",
                table: "Peminjamans");

            migrationBuilder.DropForeignKey(
                name: "FK_Peminjamans_Users_UserIdUser",
                table: "Peminjamans");

            migrationBuilder.DropIndex(
                name: "IX_Peminjamans_BukuIdBuku",
                table: "Peminjamans");

            migrationBuilder.DropIndex(
                name: "IX_Peminjamans_UserIdUser",
                table: "Peminjamans");

            migrationBuilder.DropColumn(
                name: "BukuIdBuku",
                table: "Peminjamans");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Peminjamans");

            migrationBuilder.CreateIndex(
                name: "IX_Peminjamans_IdBuku",
                table: "Peminjamans",
                column: "IdBuku");

            migrationBuilder.CreateIndex(
                name: "IX_Peminjamans_IdUser",
                table: "Peminjamans",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjamans_Bukus_IdBuku",
                table: "Peminjamans",
                column: "IdBuku",
                principalTable: "Bukus",
                principalColumn: "IdBuku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjamans_Users_IdUser",
                table: "Peminjamans",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peminjamans_Bukus_IdBuku",
                table: "Peminjamans");

            migrationBuilder.DropForeignKey(
                name: "FK_Peminjamans_Users_IdUser",
                table: "Peminjamans");

            migrationBuilder.DropIndex(
                name: "IX_Peminjamans_IdBuku",
                table: "Peminjamans");

            migrationBuilder.DropIndex(
                name: "IX_Peminjamans_IdUser",
                table: "Peminjamans");

            migrationBuilder.AddColumn<int>(
                name: "BukuIdBuku",
                table: "Peminjamans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Peminjamans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peminjamans_BukuIdBuku",
                table: "Peminjamans",
                column: "BukuIdBuku");

            migrationBuilder.CreateIndex(
                name: "IX_Peminjamans_UserIdUser",
                table: "Peminjamans",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjamans_Bukus_BukuIdBuku",
                table: "Peminjamans",
                column: "BukuIdBuku",
                principalTable: "Bukus",
                principalColumn: "IdBuku");

            migrationBuilder.AddForeignKey(
                name: "FK_Peminjamans_Users_UserIdUser",
                table: "Peminjamans",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }
    }
}
