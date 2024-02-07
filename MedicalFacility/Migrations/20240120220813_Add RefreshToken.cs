using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalFacility.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 22, 23, 8, 13, 878, DateTimeKind.Local).AddTicks(9592), new DateTime(2024, 1, 25, 23, 8, 13, 878, DateTimeKind.Local).AddTicks(9625) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 26, 23, 8, 13, 878, DateTimeKind.Local).AddTicks(9628), new DateTime(2024, 2, 4, 23, 8, 13, 878, DateTimeKind.Local).AddTicks(9629) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 22, 22, 31, 8, 531, DateTimeKind.Local).AddTicks(5815), new DateTime(2024, 1, 25, 22, 31, 8, 531, DateTimeKind.Local).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 26, 22, 31, 8, 531, DateTimeKind.Local).AddTicks(5855), new DateTime(2024, 2, 4, 22, 31, 8, 531, DateTimeKind.Local).AddTicks(5857) });
        }
    }
}
