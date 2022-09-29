using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class namefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LibraryID",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "LibraryID",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
