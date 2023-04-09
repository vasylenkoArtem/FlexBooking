using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelRoomImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainStation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusStation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferTypeId = table.Column<int>(type: "int", nullable: false),
                    OriginOfferLocationId = table.Column<int>(type: "int", nullable: false),
                    DestinationOfferLocationId = table.Column<int>(type: "int", nullable: false),
                    DepartureDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailablePassengerSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingOffers_OfferLocations_DestinationOfferLocationId",
                        column: x => x.DestinationOfferLocationId,
                        principalTable: "OfferLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookingOffers_OfferLocations_OriginOfferLocationId",
                        column: x => x.OriginOfferLocationId,
                        principalTable: "OfferLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingOffers_DestinationOfferLocationId",
                table: "BookingOffers",
                column: "DestinationOfferLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingOffers_OriginOfferLocationId",
                table: "BookingOffers",
                column: "OriginOfferLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingOffers");

            migrationBuilder.DropTable(
                name: "CarOffers");

            migrationBuilder.DropTable(
                name: "HotelOffers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OfferLocations");
        }
    }
}
