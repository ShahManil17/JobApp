using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationForm.Migrations
{
    /// <inheritdoc />
    public partial class spgetAlldata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE getAllData
                AS
                BEGIN
	                SELECT * FROM BasicDetails;
                END;";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
