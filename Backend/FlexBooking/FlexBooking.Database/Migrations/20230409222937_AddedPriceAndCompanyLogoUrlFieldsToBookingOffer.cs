using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceAndCompanyLogoUrlFieldsToBookingOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyLogoUrl",
                table: "BookingOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "BookingOffers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "CompanyLogoUrl", "DepartureDateUtc", "Price" },
                values: new object[] { new DateTime(2023, 4, 10, 4, 29, 37, 300, DateTimeKind.Utc).AddTicks(3311), "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png", new DateTime(2023, 4, 9, 22, 29, 37, 300, DateTimeKind.Utc).AddTicks(3309), 800f });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "CompanyLogoUrl", "DepartureDateUtc", "Price" },
                values: new object[] { new DateTime(2023, 4, 10, 4, 29, 37, 300, DateTimeKind.Utc).AddTicks(3318), "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png", new DateTime(2023, 4, 9, 22, 29, 37, 300, DateTimeKind.Utc).AddTicks(3317), 250f });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "CompanyLogoUrl", "DepartureDateUtc", "Price" },
                values: new object[] { new DateTime(2023, 4, 10, 4, 29, 37, 300, DateTimeKind.Utc).AddTicks(3320), "https://user-images.githubusercontent.com/44374504/230798095-0d48cfde-c2b1-4db8-b2ea-8d22b36a3b96.png", new DateTime(2023, 4, 9, 22, 29, 37, 300, DateTimeKind.Utc).AddTicks(3319), 100f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyLogoUrl",
                table: "BookingOffers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookingOffers");

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 10, 2, 17, 37, 802, DateTimeKind.Utc).AddTicks(5984), new DateTime(2023, 4, 9, 20, 17, 37, 802, DateTimeKind.Utc).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 10, 2, 17, 37, 802, DateTimeKind.Utc).AddTicks(5990), new DateTime(2023, 4, 9, 20, 17, 37, 802, DateTimeKind.Utc).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 4, 10, 2, 17, 37, 802, DateTimeKind.Utc).AddTicks(5992), new DateTime(2023, 4, 9, 20, 17, 37, 802, DateTimeKind.Utc).AddTicks(5991) });
        }
    }
}
