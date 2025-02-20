using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminantionSystem_R3.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Questions",
                newName: "Head");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Head",
                table: "Questions",
                newName: "Text");

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    ExamsID = table.Column<int>(type: "int", nullable: false),
                    QuestionsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => new { x.ExamsID, x.QuestionsID });
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Exams_ExamsID",
                        column: x => x.ExamsID,
                        principalTable: "Exams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ExamQuestion_Questions_QuestionsID",
                        column: x => x.QuestionsID,
                        principalTable: "Questions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_QuestionsID",
                table: "ExamQuestion",
                column: "QuestionsID");
        }
    }
}
