using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class ChatModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<long>(nullable: true),
                    RecieverId = table.Column<long>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    DateTimeSent = table.Column<DateTime>(nullable: false),
                    purchaseFormId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatModel_AspNetUsers_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatModel_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatModel_PurchaseForm_purchaseFormId",
                        column: x => x.purchaseFormId,
                        principalTable: "PurchaseForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatModel_RecieverId",
                table: "ChatModel",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatModel_SenderId",
                table: "ChatModel",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatModel_purchaseFormId",
                table: "ChatModel",
                column: "purchaseFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatModel");
        }
    }
}
