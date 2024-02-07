using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalFacility.Migrations
{
    /// <inheritdoc />
    public partial class InsertValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "charlie@gmail.com", "Charlie", "Davis" },
                    { 2, "bob@gmail.com", "Bob", "Johnson" },
                    { 3, "grace@gmail.com", "Grace", "Miller" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "Id", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Aspirin is a common over-the-counter medication that is used to reduce pain, fever.", "Aspirin", "Analgesic" },
                    { 2, "Ibuprofen is a nonsteroidal anti-inflammatory drug (NSAID) commonly used to relieve pain.", "Ibuprofen", "NSAID" },
                    { 3, "Simvastatin is a statin medication used to lower cholesterol levels in the blood.", "Simvastatin", "Statin" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe" },
                    { 2, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith" },
                    { 3, new DateTime(2000, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matt", "Hofman" }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Description", "Dose" },
                values: new object[,]
                {
                    { 1, 2, "Description", 5 },
                    { 2, 4, "Description", 15 },
                    { 3, 1, "Description", 12 },
                    { 3, 3, "Description", 10 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 20, 22, 32, 8, 420, DateTimeKind.Local).AddTicks(4949), new DateTime(2023, 12, 23, 22, 32, 8, 420, DateTimeKind.Local).AddTicks(4979), 1, 2 },
                    { 2, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 3, new DateTime(2023, 12, 24, 22, 32, 8, 420, DateTimeKind.Local).AddTicks(4982), new DateTime(2024, 1, 2, 22, 32, 8, 420, DateTimeKind.Local).AddTicks(4984), 2, 1 },
                    { 4, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
