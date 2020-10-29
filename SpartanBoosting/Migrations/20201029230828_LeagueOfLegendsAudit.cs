using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class LeagueOfLegendsAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeagueOfLegendsAuditModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueOfLegendsAuditModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeagueOfLegendsAuditModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeagueOfLegendsAuditModel_UserId",
                table: "LeagueOfLegendsAuditModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeagueOfLegendsAuditModel");
        }
    }
}
