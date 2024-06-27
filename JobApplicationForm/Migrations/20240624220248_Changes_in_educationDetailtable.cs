using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationForm.Migrations
{
    /// <inheritdoc />
    public partial class Changes_in_educationDetailtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Technologies",
                newName: "TechName");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Technologies",
                newName: "TechLevel");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Languages",
                newName: "LangName");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Languages",
                newName: "LangLevel");

            migrationBuilder.AlterColumn<string>(
                name: "PassingYear",
                table: "EducationDetails",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BoardName",
                table: "EducationDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EduLevel",
                table: "EducationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EduLevel",
                table: "EducationDetails");

            migrationBuilder.RenameColumn(
                name: "TechName",
                table: "Technologies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TechLevel",
                table: "Technologies",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "LangName",
                table: "Languages",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LangLevel",
                table: "Languages",
                newName: "Level");

            migrationBuilder.AlterColumn<string>(
                name: "PassingYear",
                table: "EducationDetails",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "BoardName",
                table: "EducationDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
