using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartanBoosting.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PurchaseForm");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
