using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminantionSystem_R3.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "StudentsExams",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "StudentsCourses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentsExams");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentsCourses");
        }
    }
}
