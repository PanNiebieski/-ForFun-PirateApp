﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PirateApp.Data;

namespace PirateApp.Data.Migrations
{
    [DbContext(typeof(PirateContext))]
    partial class PirateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PirateApp.Domain.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CrewName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("PirateApp.Domain.Duel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Duel");
                });

            modelBuilder.Entity("PirateApp.Domain.Pirate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CrewId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("ShipId");

                    b.ToTable("Pirates");
                });

            modelBuilder.Entity("PirateApp.Domain.PirateDuel", b =>
                {
                    b.Property<int>("PirateId")
                        .HasColumnType("int");

                    b.Property<int>("DuelId")
                        .HasColumnType("int");

                    b.HasKey("PirateId", "DuelId");

                    b.HasIndex("DuelId");

                    b.ToTable("PirateDuel");
                });

            modelBuilder.Entity("PirateApp.Domain.Saying", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PirateId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PirateId");

                    b.ToTable("Sayings");
                });

            modelBuilder.Entity("PirateApp.Domain.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HowManyPeopleCanTake")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ship");
                });

            modelBuilder.Entity("PirateApp.Domain.Pirate", b =>
                {
                    b.HasOne("PirateApp.Domain.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId");

                    b.HasOne("PirateApp.Domain.Ship", "Ship")
                        .WithMany()
                        .HasForeignKey("ShipId");
                });

            modelBuilder.Entity("PirateApp.Domain.PirateDuel", b =>
                {
                    b.HasOne("PirateApp.Domain.Duel", "Duel")
                        .WithMany("PirtateDuels")
                        .HasForeignKey("DuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PirateApp.Domain.Pirate", "Pirate")
                        .WithMany("PirateDuels")
                        .HasForeignKey("PirateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PirateApp.Domain.Saying", b =>
                {
                    b.HasOne("PirateApp.Domain.Pirate", "Pirate")
                        .WithMany("Sayings")
                        .HasForeignKey("PirateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
