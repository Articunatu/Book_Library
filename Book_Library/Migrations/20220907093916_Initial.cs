using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 25, nullable: false),
                    BookStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Burrowers",
                columns: table => new
                {
                    BurrowerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 15, nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    SecurityNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burrowers", x => x.BurrowerID);
                });

            migrationBuilder.CreateTable(
                name: "Authorships",
                columns: table => new
                {
                    AuthorshipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Authorship_AuthorID = table.Column<int>(nullable: false),
                    Authorship_BookID = table.Column<int>(nullable: false),
                    AuthorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorships", x => x.AuthorshipID);
                    table.ForeignKey(
                        name: "FK_Authorships_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loan_BookID = table.Column<int>(nullable: false),
                    Loan_BurrowerID = table.Column<int>(nullable: false),
                    DateOfLoan = table.Column<DateTime>(nullable: false),
                    DateOfReturn = table.Column<DateTime>(nullable: false),
                    AmountOfLoanRenewals = table.Column<int>(nullable: false),
                    BurrowerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Burrowers_BurrowerID",
                        column: x => x.BurrowerID,
                        principalTable: "Burrowers",
                        principalColumn: "BurrowerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authorships_AuthorID",
                table: "Authorships",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BurrowerID",
                table: "Loans",
                column: "BurrowerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authorships");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Burrowers");
        }
    }
}
