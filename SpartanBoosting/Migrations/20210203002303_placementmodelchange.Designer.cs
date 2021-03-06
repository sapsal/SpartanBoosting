// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpartanBoosting.Data;

namespace SpartanBoosting.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210203002303_placementmodelchange")]
    partial class placementmodelchange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SpartanBoosting.Models.ApplicationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SpartanBoosting.Models.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscordId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte>("MaxAssignedBoostsAllowed")
                        .HasColumnType("tinyint");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SpartanBoosting.Models.BoostingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentLP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredCurrentDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredCurrentLeague")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificChampions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesADC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesJungle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesMiddle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesTop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfDuoPremium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfDuoRegular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfQueue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VPN")
                        .HasColumnType("bit");

                    b.Property<string>("YourCurrentLeague")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoostingModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.ChatModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeSent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RecieverId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<int>("purchaseFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.ToTable("ChatModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.CoachingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoachingPackage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentRank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificChampions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesADC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesJungle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesMiddle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesTop")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CoachingModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.DiscountModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<bool>("InUse")
                        .HasColumnType("bit");

                    b.Property<bool>("SingleUse")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("SpartanBoosting.Models.LeagueOfLegends_Models.LeagueOfLegendsAuditModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LeagueOfLegendsAuditModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.PersonalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("stripeToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalInformation");
                });

            modelBuilder.Entity("SpartanBoosting.Models.PlacementMatchesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastSeasonStanding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumOfGames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificChampions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesADC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesJungle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesMiddle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesTop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfDuoPremium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfDuoRegular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfQueue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfService")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlacementMatchesModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.Pricing.PurchaseForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AdminCompletionConfirmed")
                        .HasColumnType("bit");

                    b.Property<long?>("BoosterAssignedToId")
                        .HasColumnType("bigint");

                    b.Property<bool>("BoosterCompletionConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("BoosterPricing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BoostingModelId")
                        .HasColumnType("int");

                    b.Property<long?>("ClientAssignedToId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CoachingModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CustomerCompletionConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<bool>("JobAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("PayPalApproval")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayPalCapture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<int?>("PlacementMatchesModelId")
                        .HasColumnType("int");

                    b.Property<string>("Pricing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseType")
                        .HasColumnType("int");

                    b.Property<int?>("TFTBoostingModelId")
                        .HasColumnType("int");

                    b.Property<int?>("TFTPlacementModelId")
                        .HasColumnType("int");

                    b.Property<int?>("WinBoostModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoosterAssignedToId");

                    b.HasIndex("BoostingModelId");

                    b.HasIndex("ClientAssignedToId");

                    b.HasIndex("CoachingModelId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("PersonalInformationId");

                    b.HasIndex("PlacementMatchesModelId");

                    b.HasIndex("TFTBoostingModelId");

                    b.HasIndex("TFTPlacementModelId");

                    b.HasIndex("WinBoostModelId");

                    b.ToTable("PurchaseForm");
                });

            modelBuilder.Entity("SpartanBoosting.Models.TFTBoostingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentLP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredCurrentDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredCurrentLeague")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YourCurrentLeague")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TFTBoostingModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.TFTPlacementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastSeasonStanding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfGames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TFTPlacementModel");
                });

            modelBuilder.Entity("SpartanBoosting.Models.WinBoostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrentDivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumOfGames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Server")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesADC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesJungle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesMiddle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesSupport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificRolesTop")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfDuoPremium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfDuoRegular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfQueue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfService")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YourCurrentLeague")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WinBoostModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpartanBoosting.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpartanBoosting.Models.ChatModel", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationUser", "Reciever")
                        .WithMany()
                        .HasForeignKey("RecieverId");

                    b.HasOne("SpartanBoosting.Models.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("SpartanBoosting.Models.LeagueOfLegends_Models.LeagueOfLegendsAuditModel", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SpartanBoosting.Models.Pricing.PurchaseForm", b =>
                {
                    b.HasOne("SpartanBoosting.Models.ApplicationUser", "BoosterAssignedTo")
                        .WithMany()
                        .HasForeignKey("BoosterAssignedToId");

                    b.HasOne("SpartanBoosting.Models.BoostingModel", "BoostingModel")
                        .WithMany()
                        .HasForeignKey("BoostingModelId");

                    b.HasOne("SpartanBoosting.Models.ApplicationUser", "ClientAssignedTo")
                        .WithMany()
                        .HasForeignKey("ClientAssignedToId");

                    b.HasOne("SpartanBoosting.Models.CoachingModel", "CoachingModel")
                        .WithMany()
                        .HasForeignKey("CoachingModelId");

                    b.HasOne("SpartanBoosting.Models.DiscountModel", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId");

                    b.HasOne("SpartanBoosting.Models.PersonalInformation", "PersonalInformation")
                        .WithMany()
                        .HasForeignKey("PersonalInformationId");

                    b.HasOne("SpartanBoosting.Models.PlacementMatchesModel", "PlacementMatchesModel")
                        .WithMany()
                        .HasForeignKey("PlacementMatchesModelId");

                    b.HasOne("SpartanBoosting.Models.TFTBoostingModel", "TFTBoostingModel")
                        .WithMany()
                        .HasForeignKey("TFTBoostingModelId");

                    b.HasOne("SpartanBoosting.Models.TFTPlacementModel", "TFTPlacementModel")
                        .WithMany()
                        .HasForeignKey("TFTPlacementModelId");

                    b.HasOne("SpartanBoosting.Models.WinBoostModel", "WinBoostModel")
                        .WithMany()
                        .HasForeignKey("WinBoostModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
