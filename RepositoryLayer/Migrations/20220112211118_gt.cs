using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class gt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_notesTable_NotesId",
                table: "Labels");

            migrationBuilder.AlterColumn<long>(
                name: "NotesId",
                table: "Labels",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_notesTable_NotesId",
                table: "Labels",
                column: "NotesId",
                principalTable: "notesTable",
                principalColumn: "NotesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Labels_notesTable_NotesId",
                table: "Labels");

            migrationBuilder.AlterColumn<long>(
                name: "NotesId",
                table: "Labels",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_notesTable_NotesId",
                table: "Labels",
                column: "NotesId",
                principalTable: "notesTable",
                principalColumn: "NotesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
