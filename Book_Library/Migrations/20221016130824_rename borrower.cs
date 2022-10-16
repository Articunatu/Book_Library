using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class renameborrower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Burrowers_BurrowerID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Burrowers_BurrowerID",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Burrowers");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BurrowerID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BurrowerID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BurrowerID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BurrowerID",
                table: "Loans");

            migrationBuilder.AddColumn<int>(
                name: "BorrowerID",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BorrowerID",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    BorrowerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 15, nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SecurityNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.BorrowerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BorrowerID",
                table: "Reservations",
                column: "BorrowerID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BorrowerID",
                table: "Loans",
                column: "BorrowerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Borrowers_BorrowerID",
                table: "Loans",
                column: "BorrowerID",
                principalTable: "Borrowers",
                principalColumn: "BorrowerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Borrowers_BorrowerID",
                table: "Reservations",
                column: "BorrowerID",
                principalTable: "Borrowers",
                principalColumn: "BorrowerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
