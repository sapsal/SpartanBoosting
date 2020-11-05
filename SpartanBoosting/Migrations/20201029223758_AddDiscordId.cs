using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class AddDiscordId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatModel_PurchaseForm_purchaseFormId",
                table: "ChatModel");

            migrationBuilder.DropIndex(
                name: "IX_ChatModel_purchaseFormId",
                table: "ChatModel");

            migrationBuilder.AlterColumn<int>(
                name: "purchaseFormId",
                table: "ChatModel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscordId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscordId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "purchaseFormId",
                table: "ChatModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ChatModel_purchaseFormId",
                table: "ChatModel",
                column: "purchaseFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatModel_PurchaseForm_purchaseFormId",
                table: "ChatModel",
                column: "purchaseFormId",
                principalTable: "PurchaseForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
