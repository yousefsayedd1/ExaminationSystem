using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminantionSystem_R3.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamsQuestion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamsQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamsQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExamsQuestion_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ExamsQuestion_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamsQuestion_ExamID",
                table: "ExamsQuestion",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamsQuestion_QuestionID",
                table: "ExamsQuestion",
                column: "QuestionID");
        }
    }
}
