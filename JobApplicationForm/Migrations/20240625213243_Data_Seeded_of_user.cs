using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationForm.Migrations
{
    /// <inheritdoc />
    public partial class Data_Seeded_of_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6581ebeb-2e63-4391-94af-7137ae4eed1a", 0, "1bbc9e13-786a-449d-9d03-3fbc07128065", "manil.shah@gmail.com", false, true, null, "MANIL", null, "AQAAAAIAAYagAAAAEHHNba5wWUQ/qPhBe9ouYqAtYWXL1u+H9YmNE1OVmu5obXHNDpaQF+XlqVjWSI2kXA==", null, false, "R5Y77KK57HYHACKQVOQY2AN7EJV3ABWT", false, "manil" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6581ebeb-2e63-4391-94af-7137ae4eed1a");
        }
    }
}
