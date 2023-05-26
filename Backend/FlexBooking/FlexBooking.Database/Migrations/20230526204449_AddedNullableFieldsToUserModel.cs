using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexBooking.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddedNullableFieldsToUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
