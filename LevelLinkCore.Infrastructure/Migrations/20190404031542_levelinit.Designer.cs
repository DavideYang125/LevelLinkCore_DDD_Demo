﻿// <auto-generated />
using LevelLinkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LevelLinkCore.Infrastructure.Migrations
{
    [DbContext(typeof(LevelLinkContext))]
    [Migration("20190404031542_levelinit")]
    partial class levelinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LevelLinkCore.Domain.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("ProvinceId");

                    b.Property<string>("Unique")
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.ToTable("citys");
                });

            modelBuilder.Entity("LevelLinkCore.Domain.Model.CityInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("GdpSize")
                        .HasColumnName("gdp_size");

                    b.Property<double>("Population");

                    b.HasKey("Id");

                    b.ToTable("city_info");
                });

            modelBuilder.Entity("LevelLinkCore.Domain.Model.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Unique");

                    b.HasKey("Id");

                    b.ToTable("provinces");
                });

            modelBuilder.Entity("LevelLinkCore.Domain.Model.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Unique");

                    b.HasKey("Id");

                    b.ToTable("regions");
                });
#pragma warning restore 612, 618
        }
    }
}
