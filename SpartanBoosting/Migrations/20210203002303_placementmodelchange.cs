using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class placementmodelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecificChampions",
                table: "PlacementMatchesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecificRolesADC",
                table: "PlacementMatchesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecificRolesJungle",
                table: "PlacementMatchesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecificRolesMiddle",
                table: "PlacementMatchesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecificRolesSupport",
                table: "PlacementMatchesModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecificRolesTop",
                table: "PlacementMatchesModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecificChampions",
                table: "PlacementMatchesModel");

            migrationBuilder.DropColumn(
                name: "SpecificRolesADC",
                table: "PlacementMatchesModel");

            migrationBuilder.DropColumn(
                name: "SpecificRolesJungle",
                table: "PlacementMatchesModel");

            migrationBuilder.DropColumn(
                name: "SpecificRolesMiddle",
                table: "PlacementMatchesModel");

            migrationBuilder.DropColumn(
                name: "SpecificRolesSupport",
                table: "PlacementMatchesModel");

            migrationBuilder.DropColumn(
                name: "SpecificRolesTop",
                table: "PlacementMatchesModel");
        }
    }
}
