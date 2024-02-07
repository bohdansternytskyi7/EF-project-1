using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalFacility.Migrations
{
    /// <inheritdoc />
    public partial class HotFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

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
    }
}
