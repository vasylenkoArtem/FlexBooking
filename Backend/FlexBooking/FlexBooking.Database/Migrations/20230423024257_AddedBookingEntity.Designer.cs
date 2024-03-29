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
    [Migration("20230423024257_AddedBookingEntity")]
    partial class AddedBookingEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlexBooking.Domain.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookingOfferId")
                        .HasColumnType("int");

                    b.Property<int?>("CarOffersId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelOffersId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerSeats")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookingOfferId");

                    b.HasIndex("CarOffersId");

                    b.HasIndex("HotelOffersId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.BookingOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("AvailablePassengerSeats")
                        .HasColumnType("int");

                    b.Property<string>("CompanyLogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationOfferLocationId")
                        .HasColumnType("int");

                    b.Property<int>("OfferTypeId")
                        .HasColumnType("int");

                    b.Property<int>("OriginOfferLocationId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DestinationOfferLocationId");

                    b.HasIndex("OriginOfferLocationId");

                    b.ToTable("BookingOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalDateUtc = new DateTime(2023, 4, 23, 8, 42, 57, 735, DateTimeKind.Utc).AddTicks(8826),
                            AvailablePassengerSeats = 100,
                            CompanyLogoUrl = "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png",
                            DepartureDateUtc = new DateTime(2023, 4, 23, 2, 42, 57, 735, DateTimeKind.Utc).AddTicks(8824),
                            DestinationOfferLocationId = 2,
                            OfferTypeId = 1,
                            OriginOfferLocationId = 1,
                            Price = 800f
                        },
                        new
                        {
                            Id = 2,
                            ArrivalDateUtc = new DateTime(2023, 4, 23, 8, 42, 57, 735, DateTimeKind.Utc).AddTicks(8837),
                            AvailablePassengerSeats = 100,
                            CompanyLogoUrl = "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png",
                            DepartureDateUtc = new DateTime(2023, 4, 23, 2, 42, 57, 735, DateTimeKind.Utc).AddTicks(8837),
                            DestinationOfferLocationId = 4,
                            OfferTypeId = 2,
                            OriginOfferLocationId = 3,
                            Price = 250f
                        },
                        new
                        {
                            Id = 3,
                            ArrivalDateUtc = new DateTime(2023, 4, 23, 8, 42, 57, 735, DateTimeKind.Utc).AddTicks(8839),
                            AvailablePassengerSeats = 100,
                            CompanyLogoUrl = "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png",
                            DepartureDateUtc = new DateTime(2023, 4, 23, 2, 42, 57, 735, DateTimeKind.Utc).AddTicks(8839),
                            DestinationOfferLocationId = 6,
                            OfferTypeId = 3,
                            OriginOfferLocationId = 5,
                            Price = 100f
                        });
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.CarOffer", b =>
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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/toyota/camry_lrg.jpg",
                            City = "Toronto",
                            Price = 100m,
                            Title = "Regular sedan Audi"
                        },
                        new
                        {
                            Id = 2,
                            CarImageUrl = "https://cdn2.rcstatic.com/images/car_images/web/dodge/durango_lrg.jpg",
                            City = "Montreal",
                            Price = 120m,
                            Title = "Special SUV BMW X2"
                        });
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.HotelOffer", b =>
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

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HotelOffers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Toronto",
                            HotelRoomImageUrl = "https://cf.bstatic.com/xdata/images/hotel/square200/64371688.webp?k=5ef28b75a00b6ef33e969c56783827d927a8a5d3bdfdd71c450b6477d725a7b7&o=&s=1",
                            Price = 70m,
                            Title = "San Marine Hotel 4 Star"
                        },
                        new
                        {
                            Id = 2,
                            City = "Montreal",
                            HotelRoomImageUrl = "https://cf.bstatic.com/xdata/images/hotel/square200/232812146.webp?k=76f9ea6d899b7ff326616e78653a8b83af7b276dd74ed07ed7d04a7e8c5c8aa6&o=&s=1",
                            Price = 115m,
                            Title = "Amazing View to Falls Hotel"
                        });
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.OfferLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainStation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OfferLocations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AirportCode = "YYZ",
                            City = "Toronto"
                        },
                        new
                        {
                            Id = 2,
                            AirportCode = "YUL",
                            City = "Montreal"
                        },
                        new
                        {
                            Id = 3,
                            City = "Toronto",
                            TrainStation = "Union Station"
                        },
                        new
                        {
                            Id = 4,
                            City = "Montreal",
                            TrainStation = "Central Station"
                        },
                        new
                        {
                            Id = 5,
                            BusStation = "Toronto Bus Station",
                            City = "Toronto"
                        },
                        new
                        {
                            Id = 6,
                            BusStation = "Montreal Bus Station",
                            City = "Montreal"
                        });
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.User", b =>
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

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "123456",
                            RoleId = 1,
                            Username = "TestClient"
                        },
                        new
                        {
                            Id = 2,
                            Password = "123456",
                            RoleId = 2,
                            Username = "TestAdmin"
                        });
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.Booking", b =>
                {
                    b.HasOne("FlexBooking.Domain.Models.BookingOffer", "BookingOffer")
                        .WithMany()
                        .HasForeignKey("BookingOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexBooking.Domain.Models.CarOffer", "CarOffers")
                        .WithMany()
                        .HasForeignKey("CarOffersId");

                    b.HasOne("FlexBooking.Domain.Models.HotelOffer", "HotelOffers")
                        .WithMany()
                        .HasForeignKey("HotelOffersId");

                    b.HasOne("FlexBooking.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingOffer");

                    b.Navigation("CarOffers");

                    b.Navigation("HotelOffers");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlexBooking.Domain.Models.BookingOffer", b =>
                {
                    b.HasOne("FlexBooking.Domain.Models.OfferLocation", "DestinationOfferLocation")
                        .WithMany()
                        .HasForeignKey("DestinationOfferLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlexBooking.Domain.Models.OfferLocation", "OriginOfferLocation")
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
