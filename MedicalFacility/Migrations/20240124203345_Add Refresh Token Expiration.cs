using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalFacility.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenExpiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiration",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 26, 21, 33, 45, 566, DateTimeKind.Local).AddTicks(7682), new DateTime(2024, 1, 29, 21, 33, 45, 566, DateTimeKind.Local).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 30, 21, 33, 45, 566, DateTimeKind.Local).AddTicks(7713), new DateTime(2024, 2, 8, 21, 33, 45, 566, DateTimeKind.Local).AddTicks(7714) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiration",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 22, 23, 30, 52, 82, DateTimeKind.Local).AddTicks(6996), new DateTime(2024, 1, 25, 23, 30, 52, 82, DateTimeKind.Local).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 26, 23, 30, 52, 82, DateTimeKind.Local).AddTicks(7026), new DateTime(2024, 2, 4, 23, 30, 52, 82, DateTimeKind.Local).AddTicks(7027) });
        }
    }
}
