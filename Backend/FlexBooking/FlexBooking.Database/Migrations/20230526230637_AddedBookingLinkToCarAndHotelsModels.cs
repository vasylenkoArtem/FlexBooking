using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingLinkToCarAndHotelsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarOfferId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelOfferId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 5, 6, 37, 549, DateTimeKind.Utc).AddTicks(4495), new DateTime(2023, 5, 26, 23, 6, 37, 549, DateTimeKind.Utc).AddTicks(4493) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 5, 6, 37, 549, DateTimeKind.Utc).AddTicks(4507), new DateTime(2023, 5, 26, 23, 6, 37, 549, DateTimeKind.Utc).AddTicks(4507) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 5, 6, 37, 549, DateTimeKind.Utc).AddTicks(4509), new DateTime(2023, 5, 26, 23, 6, 37, 549, DateTimeKind.Utc).AddTicks(4508) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarOfferId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelOfferId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 5, 0, 20, 742, DateTimeKind.Utc).AddTicks(6080), new DateTime(2023, 5, 26, 23, 0, 20, 742, DateTimeKind.Utc).AddTicks(6076) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 5, 0, 20, 742, DateTimeKind.Utc).AddTicks(6091), new DateTime(2023, 5, 26, 23, 0, 20, 742, DateTimeKind.Utc).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 5, 0, 20, 742, DateTimeKind.Utc).AddTicks(6093), new DateTime(2023, 5, 26, 23, 0, 20, 742, DateTimeKind.Utc).AddTicks(6093) });
        }
    }
}
