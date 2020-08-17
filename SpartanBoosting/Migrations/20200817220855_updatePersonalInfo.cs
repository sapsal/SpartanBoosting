using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class updatePersonalInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "JobAvailable",
                table: "PurchaseForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PayPalApproval",
                table: "PurchaseForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayPalCapture",
                table: "PurchaseForm",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobAvailable",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "PayPalApproval",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "PayPalCapture",
                table: "PurchaseForm");
        }
    }
}
