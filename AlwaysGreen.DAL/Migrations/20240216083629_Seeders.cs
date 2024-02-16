using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlwaysGreen.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "City", "Country", "StreetName", "StreetNumber", "Unit", "UnitNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, null, "Anverse", "Belgique", "test", "10", null, null, "2000" },
                    { 2, null, "Bruxelles", "Belgique", "ste", "1", null, null, "1000" }
                });

            migrationBuilder.InsertData(
                table: "Emptybottles",
                columns: new[] { "Id", "Prix", "Quantity", "TypeName" },
                values: new object[,]
                {
                    { 1, 10f, 10, "shampoo" },
                    { 2, 10f, 10, "dishwashingLiquid" },
                    { 3, 10f, 10, "laundryDetergent" },
                    { 4, 10f, 10, "softener" }
                });

            migrationBuilder.InsertData(
                table: "Couriers",
                columns: new[] { "Id", "AddressId", "Email", "IsActive", "Name", "PhoneNumber", "VATnumber" },
                values: new object[] { 1, 1, "courierUser@test.com", true, "TestCourier", "+32234567", "1234" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Couriers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emptybottles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Emptybottles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Emptybottles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Emptybottles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
