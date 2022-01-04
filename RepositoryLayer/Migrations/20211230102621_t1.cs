using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "notesTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notesTable_userId",
                table: "notesTable",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_notesTable_Users_userId",
                table: "notesTable",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notesTable_Users_userId",
                table: "notesTable");

            migrationBuilder.DropIndex(
                name: "IX_notesTable_userId",
                table: "notesTable");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "notesTable");
        }
    }
}
