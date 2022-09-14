using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class Authorshipnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorships_Authors_AuthorID",
                table: "Authorships");

            migrationBuilder.DropColumn(
                name: "Authorship_AuthorID",
                table: "Authorships");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Authorships",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorships_Authors_AuthorID",
                table: "Authorships",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorships_Authors_AuthorID",
                table: "Authorships");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Authorships",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Authorship_AuthorID",
                table: "Authorships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Authorships_Authors_AuthorID",
                table: "Authorships",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
