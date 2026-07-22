using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlace.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedItemExpireDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ListingExpiryDate",
                table: "Items",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2026, 8, 11, 14, 41, 12, 687, DateTimeKind.Utc).AddTicks(9442));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ListingExpiryDate",
                table: "Items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2026, 8, 11, 14, 41, 12, 687, DateTimeKind.Utc).AddTicks(9442),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
