using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mapping.Migrations
{
    /// <inheritdoc />
    public partial class addQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    OfficeName = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: false),
                    OfficeLocation = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MeetingDay = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quiz_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: false),
                    OfficeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Corprate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corprate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corprate_Participant_Id",
                        column: x => x.Id,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false),
                    YearOfGraduation = table.Column<int>(type: "integer", nullable: false),
                    IsIntern = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individual_Participant_Id",
                        column: x => x.Id,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    OptionA = table.Column<string>(type: "text", nullable: false),
                    OptionB = table.Column<string>(type: "text", nullable: false),
                    OptionC = table.Column<string>(type: "text", nullable: false),
                    OptionD = table.Column<string>(type: "text", nullable: false),
                    CorrectAnswer = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuizes_Quiz_id",
                        column: x => x.id,
                        principalTable: "Quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrueAndFalseQuizes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswer = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueAndFalseQuizes", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrueAndFalseQuizes_Quiz_id",
                        column: x => x.id,
                        principalTable: "Quiz",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    SectionName = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    InstructorId = table.Column<int>(type: "integer", nullable: true),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Section_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Section_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    ParticipantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.SectionId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Math", 30m },
                    { 2, "English", 70m },
                    { 3, "Arabic", 40m },
                    { 4, "Science", 50m },
                    { 5, "History", 20m }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "Id", "OfficeLocation", "OfficeName" },
                values: new object[,]
                {
                    { 1, "building A", "Off_05" },
                    { 2, "building B", "Off_12" },
                    { 3, "Adminstration", "Off_32" },
                    { 4, "IT Department", "Off_44" },
                    { 5, "IT Department", "Off_43" }
                });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "MeetingDay", "Title" },
                values: new object[,]
                {
                    { 1, "17", "Daily" },
                    { 2, "66", "TwiceAWeek" },
                    { 3, "40", "Weekend" },
                    { 4, "36", "DayAfterDay" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "FName", "LName", "OfficeId" },
                values: new object[,]
                {
                    { 1, "Ahmed", " Ali", 1 },
                    { 2, "Momen", " Ahmed", 2 },
                    { 3, "Beshoy", " Ashraf", 3 },
                    { 4, "Mena ", "Maged", 4 },
                    { 5, "Boles ", "Gorge", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ParticipantId",
                table: "Enrollments",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_OfficeId",
                table: "Instructor",
                column: "OfficeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_CourseId",
                table: "Quiz",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CourseId",
                table: "Section",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_InstructorId",
                table: "Section",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_ScheduleId",
                table: "Section",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corprate");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Individual");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuizes");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "TrueAndFalseQuizes");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Office");
        }
    }
}
