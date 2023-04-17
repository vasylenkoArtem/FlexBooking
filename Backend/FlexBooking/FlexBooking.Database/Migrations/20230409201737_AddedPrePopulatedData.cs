using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrePopulatedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarOffers",
                columns: new[] { "Id", "CarImageUrl", "City", "Price" },
                values: new object[,]
                {
                    { 1, "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", "Toronto", 100m },
                    { 2, "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", "Montreal", 100m }
                });

            migrationBuilder.InsertData(
                table: "HotelOffers",
                columns: new[] { "Id", "City", "HotelRoomImageUrl", "Price" },
                values: new object[,]
                {
                    { 1, "Toronto", "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", 100m },
                    { 2, "Montreal", "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", 100m }
                });

            migrationBuilder.InsertData(
                table: "OfferLocations",
                columns: new[] { "Id", "AirportCode", "BusStation", "City", "TrainStation" },
                values: new object[,]
                {
                    { 1, "YYZ", null, "Toronto", null },
                    { 2, "YUL", null, "Montreal", null },
                    { 3, null, null, "Toronto", "Union Station" },
                    { 4, null, null, "Montreal", "Central Station" },
                    { 5, null, "Toronto Bus Station", "Toronto", null },
                    { 6, null, "Montreal Bus Station", "Montreal", null }
                });

            migrationBuilder.InsertData(
                table: "BookingOffers",
                columns: new[] { "Id", "ArrivalDateUtc", "AvailablePassengerSeats", "DepartureDateUtc", "DestinationOfferLocationId", "OfferTypeId", "OriginOfferLocationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 10, 2, 17, 37, 802, DateTimeKind.Utc).AddTicks(5984), 100, new DateTime(2023, 4, 9, 20, 17, 37, 802, DateTimeKind.Utc).AddTicks(5982), 2, 1, 1 },
                    { 2, new DateTime(2023, 4, 10, 2, 17, 37, 802, DateTimeKind.Utc).AddTicks(5990), 100, new DateTime(2023, 4, 9, 20, 17, 37, 802, DateTimeKind.Utc).AddTicks(5990), 4, 2, 3 },
                    { 3, new DateTime(2023, 4, 10, 2, 17, 37, 802, DateTimeKind.Utc).AddTicks(5992), 100, new DateTime(2023, 4, 9, 20, 17, 37, 802, DateTimeKind.Utc).AddTicks(5991), 6, 3, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OfferLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OfferLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OfferLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OfferLocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OfferLocations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OfferLocations",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
