using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFieldsToBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserFullName",
                table: "Bookings",
                newName: "VisaNumber");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportFullName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "test@i.ua", "+1999999999" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Phone" },
                values: new object[] { "test@i.ua", "+1999999999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PassportFullName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "VisaNumber",
                table: "Bookings",
                newName: "UserFullName");

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
        }
    }
}
