using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentFieldsToTheOffer : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarOfferId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HotelOfferId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "HotelOffers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "CarOffers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                table: "Bookings",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 2, 14, 24, 788, DateTimeKind.Utc).AddTicks(9052), new DateTime(2023, 5, 26, 20, 14, 24, 788, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 2, 14, 24, 788, DateTimeKind.Utc).AddTicks(9065), new DateTime(2023, 5, 26, 20, 14, 24, 788, DateTimeKind.Utc).AddTicks(9064) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 2, 14, 24, 788, DateTimeKind.Utc).AddTicks(9066), new DateTime(2023, 5, 26, 20, 14, 24, 788, DateTimeKind.Utc).AddTicks(9066) });

            migrationBuilder.UpdateData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookingId",
                value: null);

            migrationBuilder.UpdateData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "BookingId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_HotelOffers_BookingId",
                table: "HotelOffers",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOffers_BookingId",
                table: "CarOffers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarOffers_Bookings_BookingId",
                table: "CarOffers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelOffers_Bookings_BookingId",
                table: "HotelOffers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarOffers_Bookings_BookingId",
                table: "CarOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelOffers_Bookings_BookingId",
                table: "HotelOffers");

            migrationBuilder.DropIndex(
                name: "IX_HotelOffers_BookingId",
                table: "HotelOffers");

            migrationBuilder.DropIndex(
                name: "IX_CarOffers_BookingId",
                table: "CarOffers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "HotelOffers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "CarOffers");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Cvv",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 7, 6, 49, 20, 951, DateTimeKind.Utc).AddTicks(9706), new DateTime(2023, 5, 7, 0, 49, 20, 951, DateTimeKind.Utc).AddTicks(9705) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 7, 6, 49, 20, 951, DateTimeKind.Utc).AddTicks(9714), new DateTime(2023, 5, 7, 0, 49, 20, 951, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 7, 6, 49, 20, 951, DateTimeKind.Utc).AddTicks(9716), new DateTime(2023, 5, 7, 0, 49, 20, 951, DateTimeKind.Utc).AddTicks(9716) });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarOfferId",
                table: "Bookings",
                column: "CarOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelOfferId",
                table: "Bookings",
                column: "HotelOfferId");

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
    }
}
