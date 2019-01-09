﻿// <auto-generated />
using System;
using Lottery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lottery.Data.Migrations
{
    [DbContext(typeof(LotteryContext))]
    [Migration("20181230203304_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lottery.Domain.Draw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("LotteryGameId");

                    b.HasKey("Id");

                    b.HasIndex("LotteryGameId");

                    b.ToTable("Draws");
                });

            modelBuilder.Entity("Lottery.Domain.DrawNumber", b =>
                {
                    b.Property<int>("DrawId");

                    b.Property<int>("Number");

                    b.Property<int?>("Position");

                    b.HasKey("DrawId", "Number");

                    b.ToTable("DrawNumber");
                });

            modelBuilder.Entity("Lottery.Domain.LotteryGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaximumNumber");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("NumberOfNumbersInADraw");

                    b.HasKey("Id");

                    b.ToTable("LotteryGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaximumNumber = 45,
                            Name = "National Lottery",
                            NumberOfNumbersInADraw = 6
                        },
                        new
                        {
                            Id = 2,
                            MaximumNumber = 70,
                            Name = "Keeno",
                            NumberOfNumbersInADraw = 20
                        });
                });

            modelBuilder.Entity("Lottery.Domain.Draw", b =>
                {
                    b.HasOne("Lottery.Domain.LotteryGame", "LotteryGame")
                        .WithMany("Draws")
                        .HasForeignKey("LotteryGameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Lottery.Domain.DrawNumber", b =>
                {
                    b.HasOne("Lottery.Domain.Draw", "Draw")
                        .WithMany("DrawNumbers")
                        .HasForeignKey("DrawId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
