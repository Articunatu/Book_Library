using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class removechecklist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Burrowers_BurrowerID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BurrowerID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BurrowerID",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BurrowerID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BurrowerID",
                table: "Books",
                column: "BurrowerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Burrowers_BurrowerID",
                table: "Books",
                column: "BurrowerID",
                principalTable: "Burrowers",
                principalColumn: "BurrowerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
