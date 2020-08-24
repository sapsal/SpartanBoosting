using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class AddBoosterInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BoosterCompletionConfirmed",
                table: "PurchaseForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BoosterPricing",
                table: "PurchaseForm",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CustomerCompletionConfirmed",
                table: "PurchaseForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoosterCompletionConfirmed",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "BoosterPricing",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "CustomerCompletionConfirmed",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");
        }
    }
}
