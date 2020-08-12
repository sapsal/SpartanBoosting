﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpartanBoosting.Models.Data;

namespace SpartanBoosting.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int?>("BoostingModelId")
                        .HasColumnType("int");

                    b.Property<int?>("CoachingModelId")
                        .HasColumnType("int");

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

                    b.HasIndex("BoostingModelId");

                    b.HasIndex("CoachingModelId");

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

            modelBuilder.Entity("SpartanBoosting.Models.Pricing.PurchaseForm", b =>
                {
                    b.HasOne("SpartanBoosting.Models.BoostingModel", "BoostingModel")
                        .WithMany()
                        .HasForeignKey("BoostingModelId");

                    b.HasOne("SpartanBoosting.Models.CoachingModel", "CoachingModel")
                        .WithMany()
                        .HasForeignKey("CoachingModelId");

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
