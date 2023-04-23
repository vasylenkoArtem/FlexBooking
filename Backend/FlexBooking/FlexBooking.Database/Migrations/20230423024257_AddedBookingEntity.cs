using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookingOfferId = table.Column<int>(type: "int", nullable: false),
                    PassengerSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarOffersId = table.Column<int>(type: "int", nullable: true),
                    HotelOffersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingOffers_BookingOfferId",
                        column: x => x.BookingOfferId,
                        principalTable: "BookingOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_CarOffers_CarOffersId",
                        column: x => x.CarOffersId,
                        principalTable: "CarOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_HotelOffers_HotelOffersId",
                        column: x => x.HotelOffersId,
                        principalTable: "HotelOffers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Bookings_BookingOfferId",
                table: "Bookings",
                column: "BookingOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarOffersId",
                table: "Bookings",
                column: "CarOffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelOffersId",
                table: "Bookings",
                column: "HotelOffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 16, 0, 39, 22, 952, DateTimeKind.Utc).AddTicks(7353), new DateTime(2023, 4, 15, 18, 39, 22, 952, DateTimeKind.Utc).AddTicks(7351) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 16, 0, 39, 22, 952, DateTimeKind.Utc).AddTicks(7366), new DateTime(2023, 4, 15, 18, 39, 22, 952, DateTimeKind.Utc).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 16, 0, 39, 22, 952, DateTimeKind.Utc).AddTicks(7368), new DateTime(2023, 4, 15, 18, 39, 22, 952, DateTimeKind.Utc).AddTicks(7367) });
        }
    }
}
