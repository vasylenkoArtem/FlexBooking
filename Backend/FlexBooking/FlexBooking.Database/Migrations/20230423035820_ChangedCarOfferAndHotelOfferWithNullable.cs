using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCarOfferAndHotelOfferWithNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CarOffers_CarOfferId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelOffers_HotelOfferId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "HotelOfferId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CarOfferId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 58, 20, 789, DateTimeKind.Utc).AddTicks(2952), new DateTime(2023, 4, 23, 3, 58, 20, 789, DateTimeKind.Utc).AddTicks(2951) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 58, 20, 789, DateTimeKind.Utc).AddTicks(2962), new DateTime(2023, 4, 23, 3, 58, 20, 789, DateTimeKind.Utc).AddTicks(2961) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 58, 20, 789, DateTimeKind.Utc).AddTicks(2963), new DateTime(2023, 4, 23, 3, 58, 20, 789, DateTimeKind.Utc).AddTicks(2963) });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CarOffers_CarOfferId",
                table: "Bookings",
                column: "CarOfferId",
                principalTable: "CarOffers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelOffers_HotelOfferId",
                table: "Bookings",
                column: "HotelOfferId",
                principalTable: "HotelOffers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CarOffers_CarOfferId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelOffers_HotelOfferId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "HotelOfferId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarOfferId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 55, 58, 891, DateTimeKind.Utc).AddTicks(1198), new DateTime(2023, 4, 23, 3, 55, 58, 891, DateTimeKind.Utc).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 55, 58, 891, DateTimeKind.Utc).AddTicks(1207), new DateTime(2023, 4, 23, 3, 55, 58, 891, DateTimeKind.Utc).AddTicks(1207) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 9, 55, 58, 891, DateTimeKind.Utc).AddTicks(1209), new DateTime(2023, 4, 23, 3, 55, 58, 891, DateTimeKind.Utc).AddTicks(1209) });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CarOffers_CarOfferId",
                table: "Bookings",
                column: "CarOfferId",
                principalTable: "CarOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelOffers_HotelOfferId",
                table: "Bookings",
                column: "HotelOfferId",
                principalTable: "HotelOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
