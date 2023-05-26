using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemovedMaxLegthFromCvv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cvv",
                table: "Bookings",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 2, 44, 48, 990, DateTimeKind.Utc).AddTicks(9186), new DateTime(2023, 5, 26, 20, 44, 48, 990, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 2, 44, 48, 990, DateTimeKind.Utc).AddTicks(9195), new DateTime(2023, 5, 26, 20, 44, 48, 990, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "BookingOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalDateUtc", "DepartureDateUtc" },
                values: new object[] { new DateTime(2023, 5, 27, 2, 44, 48, 990, DateTimeKind.Utc).AddTicks(9196), new DateTime(2023, 5, 26, 20, 44, 48, 990, DateTimeKind.Utc).AddTicks(9196) });
        }
    }
}
