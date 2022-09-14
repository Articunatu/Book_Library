using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class nullableshelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Shelves_ShelfID",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "Authorship_BookID",
                table: "Authorships");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfID",
                table: "Copies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Authorships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Shelves_ShelfID",
                table: "Copies",
                column: "ShelfID",
                principalTable: "Shelves",
                principalColumn: "ShelfID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Shelves_ShelfID",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Authorships");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfID",
                table: "Copies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Authorship_BookID",
                table: "Authorships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Shelves_ShelfID",
                table: "Copies",
                column: "ShelfID",
                principalTable: "Shelves",
                principalColumn: "ShelfID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
