using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoostingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YourCurrentLeague = table.Column<string>(nullable: true),
                    DesiredCurrentLeague = table.Column<string>(nullable: true),
                    CurrentDivision = table.Column<string>(nullable: true),
                    DesiredCurrentDivision = table.Column<string>(nullable: true),
                    CurrentLP = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    TypeOfQueue = table.Column<string>(nullable: true),
                    SpecificRolesTop = table.Column<string>(nullable: true),
                    SpecificRolesJungle = table.Column<string>(nullable: true),
                    SpecificRolesMiddle = table.Column<string>(nullable: true),
                    SpecificRolesADC = table.Column<string>(nullable: true),
                    SpecificRolesSupport = table.Column<string>(nullable: true),
                    TypeOfDuoRegular = table.Column<string>(nullable: true),
                    TypeOfDuoPremium = table.Column<string>(nullable: true),
                    SpecificChampions = table.Column<string>(nullable: true),
                    VPN = table.Column<bool>(nullable: false),
                    DiscountCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoostingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoachingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificChampions = table.Column<string>(nullable: true),
                    SpecificRolesTop = table.Column<string>(nullable: true),
                    SpecificRolesJungle = table.Column<string>(nullable: true),
                    SpecificRolesMiddle = table.Column<string>(nullable: true),
                    SpecificRolesADC = table.Column<string>(nullable: true),
                    SpecificRolesSupport = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    CoachingPackage = table.Column<string>(nullable: true),
                    CurrentRank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Discord = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    stripeToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacementMatchesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastSeasonStanding = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    TypeOfQueue = table.Column<string>(nullable: true),
                    TypeOfService = table.Column<string>(nullable: true),
                    TypeOfDuoRegular = table.Column<string>(nullable: true),
                    TypeOfDuoPremium = table.Column<string>(nullable: true),
                    NumOfGames = table.Column<string>(nullable: true),
                    Discount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacementMatchesModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TFTBoostingModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YourCurrentLeague = table.Column<string>(nullable: true),
                    DesiredCurrentLeague = table.Column<string>(nullable: true),
                    CurrentDivision = table.Column<string>(nullable: true),
                    DesiredCurrentDivision = table.Column<string>(nullable: true),
                    CurrentLP = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    DiscountCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFTBoostingModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TFTPlacementModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastSeasonStanding = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    NumberOfGames = table.Column<string>(nullable: true),
                    DiscountCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFTPlacementModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WinBoostModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YourCurrentLeague = table.Column<string>(nullable: true),
                    CurrentDivision = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    TypeOfService = table.Column<string>(nullable: true),
                    TypeOfQueue = table.Column<string>(nullable: true),
                    TypeOfDuoRegular = table.Column<string>(nullable: true),
                    TypeOfDuoPremium = table.Column<string>(nullable: true),
                    Discount = table.Column<string>(nullable: true),
                    NumOfGames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinBoostModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachingModelId = table.Column<int>(nullable: true),
                    BoostingModelId = table.Column<int>(nullable: true),
                    PlacementMatchesModelId = table.Column<int>(nullable: true),
                    WinBoostModelId = table.Column<int>(nullable: true),
                    PersonalInformationId = table.Column<int>(nullable: true),
                    TFTPlacementModelId = table.Column<int>(nullable: true),
                    TFTBoostingModelId = table.Column<int>(nullable: true),
                    Pricing = table.Column<string>(nullable: true),
                    PurchaseType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_BoostingModel_BoostingModelId",
                        column: x => x.BoostingModelId,
                        principalTable: "BoostingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_CoachingModel_CoachingModelId",
                        column: x => x.CoachingModelId,
                        principalTable: "CoachingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_PlacementMatchesModel_PlacementMatchesModelId",
                        column: x => x.PlacementMatchesModelId,
                        principalTable: "PlacementMatchesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_TFTBoostingModel_TFTBoostingModelId",
                        column: x => x.TFTBoostingModelId,
                        principalTable: "TFTBoostingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_TFTPlacementModel_TFTPlacementModelId",
                        column: x => x.TFTPlacementModelId,
                        principalTable: "TFTPlacementModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseForm_WinBoostModel_WinBoostModelId",
                        column: x => x.WinBoostModelId,
                        principalTable: "WinBoostModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_BoostingModelId",
                table: "PurchaseForm",
                column: "BoostingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_CoachingModelId",
                table: "PurchaseForm",
                column: "CoachingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_PersonalInformationId",
                table: "PurchaseForm",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_PlacementMatchesModelId",
                table: "PurchaseForm",
                column: "PlacementMatchesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_TFTBoostingModelId",
                table: "PurchaseForm",
                column: "TFTBoostingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_TFTPlacementModelId",
                table: "PurchaseForm",
                column: "TFTPlacementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseForm_WinBoostModelId",
                table: "PurchaseForm",
                column: "WinBoostModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseForm");

            migrationBuilder.DropTable(
                name: "BoostingModel");

            migrationBuilder.DropTable(
                name: "CoachingModel");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "PlacementMatchesModel");

            migrationBuilder.DropTable(
                name: "TFTBoostingModel");

            migrationBuilder.DropTable(
                name: "TFTPlacementModel");

            migrationBuilder.DropTable(
                name: "WinBoostModel");
        }
    }
}
