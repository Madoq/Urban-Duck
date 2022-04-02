﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrbanDuck.Data;

#nullable disable

namespace UrbanDuck.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UrbanDuck.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("UrbanDuck.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId")
                        .IsUnique();

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("UrbanDuck.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("NipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "Company 1",
                            NipCode = 10
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "Company 2",
                            NipCode = 20
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "Company 3",
                            NipCode = 30
                        });
                });

            modelBuilder.Entity("UrbanDuck.Models.Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("UrbanDuck.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ContributorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ContributorId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("UrbanDuck.Models.ListingTags", b =>
                {
                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<bool?>("GlutenFree")
                        .HasColumnType("bit");

                    b.Property<bool?>("Premade")
                        .HasColumnType("bit");

                    b.Property<bool?>("Sealed")
                        .HasColumnType("bit");

                    b.Property<bool?>("Vegan")
                        .HasColumnType("bit");

                    b.Property<bool?>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("ListingId");

                    b.ToTable("ListingTagsDb");
                });

            modelBuilder.Entity("UrbanDuck.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("UrbanDuck.Models.Address", b =>
                {
                    b.HasOne("UrbanDuck.Models.Company", "Company")
                        .WithMany("Addresses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UrbanDuck.Models.Booking", b =>
                {
                    b.HasOne("UrbanDuck.Models.Listing", null)
                        .WithOne("Booking")
                        .HasForeignKey("UrbanDuck.Models.Booking", "ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UrbanDuck.Models.Contributor", b =>
                {
                    b.HasOne("UrbanDuck.Models.Company", "Company")
                        .WithMany("Contributors")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UrbanDuck.Models.Listing", b =>
                {
                    b.HasOne("UrbanDuck.Models.Contributor", "Contributor")
                        .WithMany("Listings")
                        .HasForeignKey("ContributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("UrbanDuck.Models.ListingTags", b =>
                {
                    b.HasOne("UrbanDuck.Models.Listing", "Listing")
                        .WithMany()
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("UrbanDuck.Models.Photo", b =>
                {
                    b.HasOne("UrbanDuck.Models.Listing", "Listing")
                        .WithMany("Photos")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listing");
                });

            modelBuilder.Entity("UrbanDuck.Models.Company", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Contributors");
                });

            modelBuilder.Entity("UrbanDuck.Models.Contributor", b =>
                {
                    b.Navigation("Listings");
                });

            modelBuilder.Entity("UrbanDuck.Models.Listing", b =>
                {
                    b.Navigation("Booking")
                        .IsRequired();

                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
