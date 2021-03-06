﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VivaniBack.DAL;

namespace VivaniBack.Migrations
{
    [DbContext(typeof(VivaniDbContext))]
    [Migration("20201112093308_Added trending product left side image")]
    partial class Addedtrendingproductleftsideimage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VivaniBack.Models.HomeSlider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LittleHeader")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("homeSliders");
                });

            modelBuilder.Entity("VivaniBack.Models.TrendingProductsImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.ToTable("trendingProductsImage");
                });

            modelBuilder.Entity("VivaniBack.Models.WhyChooseUs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Heading")
                        .IsRequired();

                    b.Property<string>("Icon")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("whyChooseUs");
                });
#pragma warning restore 612, 618
        }
    }
}
