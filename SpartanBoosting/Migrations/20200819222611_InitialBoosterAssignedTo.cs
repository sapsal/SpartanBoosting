using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class InitialBoosterAssignedTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BoosterAssignedToId",
                table: "PurchaseForm",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_BoosterAssignedToId",
                table: "PurchaseForm",
                column: "BoosterAssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseForm_AspNetUsers_BoosterAssignedToId",
                table: "PurchaseForm",
                column: "BoosterAssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseForm_AspNetUsers_BoosterAssignedToId",
                table: "PurchaseForm");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseForm_BoosterAssignedToId",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "BoosterAssignedToId",
                table: "PurchaseForm");
        }
    }
}
