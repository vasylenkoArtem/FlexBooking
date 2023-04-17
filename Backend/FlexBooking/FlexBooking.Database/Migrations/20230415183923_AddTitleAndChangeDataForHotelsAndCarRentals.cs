using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleAndChangeDataForHotelsAndCarRentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "HotelOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CarOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CarImageUrl", "Title" },
                values: new object[] { "https://cdn2.rcstatic.com/images/car_images/web/toyota/camry_lrg.jpg", "Regular sedan Audi" });

            migrationBuilder.UpdateData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarImageUrl", "Price", "Title" },
                values: new object[] { "https://cdn2.rcstatic.com/images/car_images/web/dodge/durango_lrg.jpg", 120m, "Special SUV BMW X2" });

            migrationBuilder.UpdateData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HotelRoomImageUrl", "Price", "Title" },
                values: new object[] { "https://cf.bstatic.com/xdata/images/hotel/square200/64371688.webp?k=5ef28b75a00b6ef33e969c56783827d927a8a5d3bdfdd71c450b6477d725a7b7&o=&s=1", 70m, "San Marine Hotel 4 Star" });

            migrationBuilder.UpdateData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HotelRoomImageUrl", "Price", "Title" },
                values: new object[] { "https://cf.bstatic.com/xdata/images/hotel/square200/232812146.webp?k=76f9ea6d899b7ff326616e78653a8b83af7b276dd74ed07ed7d04a7e8c5c8aa6&o=&s=1", 115m, "Amazing View to Falls Hotel" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "HotelOffers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CarOffers");

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 10, 4, 29, 37, 300, DateTimeKind.Utc).AddTicks(3311), new DateTime(2023, 4, 9, 22, 29, 37, 300, DateTimeKind.Utc).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 10, 4, 29, 37, 300, DateTimeKind.Utc).AddTicks(3318), new DateTime(2023, 4, 9, 22, 29, 37, 300, DateTimeKind.Utc).AddTicks(3317) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 10, 4, 29, 37, 300, DateTimeKind.Utc).AddTicks(3320), new DateTime(2023, 4, 9, 22, 29, 37, 300, DateTimeKind.Utc).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarImageUrl",
                value: "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg");

            migrationBuilder.UpdateData(
                table: "CarOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CarImageUrl", "Price" },
                values: new object[] { "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", 100m });

            migrationBuilder.UpdateData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HotelRoomImageUrl", "Price" },
                values: new object[] { "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", 100m });

            migrationBuilder.UpdateData(
                table: "HotelOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HotelRoomImageUrl", "Price" },
                values: new object[] { "https://www.torontoairportlimousine.com/wp-content/uploads/2019/03/limo-toronto-airport.jpg", 100m });
        }
    }
}
