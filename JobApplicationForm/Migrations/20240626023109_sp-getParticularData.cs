using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationForm.Migrations
{
    /// <inheritdoc />
    public partial class spgetParticularData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE getPerticularData (@id INT)
                AS
                BEGIN
	
                    SELECT * FROM Preferences WHERE BasicDetailsId = @id;
                END;";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
