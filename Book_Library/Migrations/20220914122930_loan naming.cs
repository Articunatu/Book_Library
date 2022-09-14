using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Library.Migrations
{
    public partial class loannaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Burrowers_BurrowerID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Loan_BurrowerID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Loan_CopyID",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "BurrowerID",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopyID",
                table: "Loans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Burrowers_BurrowerID",
                table: "Loans",
                column: "BurrowerID",
                principalTable: "Burrowers",
                principalColumn: "BurrowerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Burrowers_BurrowerID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CopyID",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "BurrowerID",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Loan_BurrowerID",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Loan_CopyID",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Burrowers_BurrowerID",
                table: "Loans",
                column: "BurrowerID",
                principalTable: "Burrowers",
                principalColumn: "BurrowerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
