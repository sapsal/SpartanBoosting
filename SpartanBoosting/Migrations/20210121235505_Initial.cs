using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminCompletionConfirmed",
                table: "PurchaseForm",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ClientAssignedToId",
                table: "PurchaseForm",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PurchaseForm",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "PurchaseForm",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MaxAssignedBoostsAllowed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(nullable: true),
                    SingleUse = table.Column<bool>(nullable: false),
                    DiscountPercentage = table.Column<int>(nullable: false),
                    InUse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_ClientAssignedToId",
                table: "PurchaseForm",
                column: "ClientAssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_DiscountId",
                table: "PurchaseForm",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseForm_AspNetUsers_ClientAssignedToId",
                table: "PurchaseForm",
                column: "ClientAssignedToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseForm_Discount_DiscountId",
                table: "PurchaseForm",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseForm_AspNetUsers_ClientAssignedToId",
                table: "PurchaseForm");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseForm_Discount_DiscountId",
                table: "PurchaseForm");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseForm_ClientAssignedToId",
                table: "PurchaseForm");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseForm_DiscountId",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "AdminCompletionConfirmed",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "ClientAssignedToId",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "PurchaseForm");

            migrationBuilder.DropColumn(
                name: "MaxAssignedBoostsAllowed",
                table: "AspNetUsers");
        }
    }
}
