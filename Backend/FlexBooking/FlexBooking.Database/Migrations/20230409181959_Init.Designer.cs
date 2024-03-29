﻿// <auto-generated />
using System;
using FlexBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    [DbContext(typeof(FlexBookingContext))]
    [Migration("20230409181959_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlexBooking.Database.Models.BookingOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("AvailablePassengerSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationOfferLocationId")
                        .HasColumnType("int");

                    b.Property<int>("OfferTypeId")
                        .HasColumnType("int");

                    b.Property<int>("OriginOfferLocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationOfferLocationId");

                    b.HasIndex("OriginOfferLocationId");

                    b.ToTable("BookingOffers");
                });

            modelBuilder.Entity("FlexBooking.Database.Models.CarOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CarOffers");
                });

            modelBuilder.Entity("FlexBooking.Database.Models.HotelOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelRoomImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("HotelOffers");
                });

            modelBuilder.Entity("FlexBooking.Database.Models.OfferLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusStation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainStation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OfferLocations");
                });

            modelBuilder.Entity("FlexBooking.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlexBooking.Database.Models.BookingOffer", b =>
                {
                    b.HasOne("FlexBooking.Database.Models.OfferLocation", "DestinationOfferLocation")
                        .WithMany()
                        .HasForeignKey("DestinationOfferLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexBooking.Database.Models.OfferLocation", "OriginOfferLocation")
                        .WithMany()
                        .HasForeignKey("OriginOfferLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DestinationOfferLocation");

                    b.Navigation("OriginOfferLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
