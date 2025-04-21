using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCore13GenericRepository.Migrations
{
    /// <inheritdoc />
    public partial class addedColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "900cf392-aa1c-40c8-bb3b-f7a44854c33f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ad", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Soyad", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ecc7ecbc-42dc-435e-8b83-2d0d4aebe76f", 0, "Leyla", "4e59c3e1-9eae-4cd9-8b4b-2b68aab15966", "leyla@x.com", false, false, null, "LEYLA@X.COM", "LEYLA", "AQAAAAIAAYagAAAAEHEs2GUK4cFgETo/meehYTDSETmZUaC7FZSUcwwrbe2jO0M2pOD/Us5U/7oSmTpeaw==", null, false, "e646a57d-edb7-4920-bb0e-a030c976998b", "Tekin", false, "leyla" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecc7ecbc-42dc-435e-8b83-2d0d4aebe76f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ad", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Soyad", "TwoFactorEnabled", "UserName" },
                values: new object[] { "900cf392-aa1c-40c8-bb3b-f7a44854c33f", 0, "Leyla", "e2977576-e9b6-4326-8bbd-acf8b7266720", "leyla@x.com", false, false, null, "LEYLA@X.COM", "LEYLA", "AQAAAAIAAYagAAAAEA+oyHfutJT+ppzwwjw+BGo0XPTu4vC0QkNwRQozAb9ASXXoo87B85qkmTLkeahm4g==", null, false, "77774a7e-12ff-4b81-bf77-73d5959fc486", "Tekin", false, "leyla" });
        }
    }
}
