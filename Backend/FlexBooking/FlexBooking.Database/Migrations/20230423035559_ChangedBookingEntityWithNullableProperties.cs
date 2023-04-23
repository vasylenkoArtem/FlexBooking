using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBookingEntityWithNullableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_CarOffers_CarOffersId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelOffers_HotelOffersId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarOffersId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HotelOffersId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CarOffersId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelOffersId",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Bookings",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "PassengerSeats",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarOfferId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelOfferId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CarOfferId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelOfferId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Bookings",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengerSeats",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarOffersId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelOffersId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 42, 57, 735, DateTimeKind.Utc).AddTicks(8826), new DateTime(2023, 4, 23, 2, 42, 57, 735, DateTimeKind.Utc).AddTicks(8824) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 42, 57, 735, DateTimeKind.Utc).AddTicks(8837), new DateTime(2023, 4, 23, 2, 42, 57, 735, DateTimeKind.Utc).AddTicks(8837) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 23, 8, 42, 57, 735, DateTimeKind.Utc).AddTicks(8839), new DateTime(2023, 4, 23, 2, 42, 57, 735, DateTimeKind.Utc).AddTicks(8839) });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarOffersId",
                table: "Bookings",
                column: "CarOffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelOffersId",
                table: "Bookings",
                column: "HotelOffersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_CarOffers_CarOffersId",
                table: "Bookings",
                column: "CarOffersId",
                principalTable: "CarOffers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelOffers_HotelOffersId",
                table: "Bookings",
                column: "HotelOffersId",
                principalTable: "HotelOffers",
                principalColumn: "Id");
        }
    }
}
