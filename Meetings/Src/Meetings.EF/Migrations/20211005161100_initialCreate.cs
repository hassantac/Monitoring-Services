using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meetings.EF.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalenderEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedSchool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalenderEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade_Id = table.Column<long>(type: "bigint", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operator_Id = table.Column<long>(type: "bigint", nullable: false),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject_Id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolType = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emirate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviaton = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator_Id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Operators_Operator_Id",
                        column: x => x.Operator_Id,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<long>(type: "bigint", nullable: false),
                    Event_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEvents_CalenderEvents_Event_Id",
                        column: x => x.Event_Id,
                        principalTable: "CalenderEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolGrades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    School_Id = table.Column<long>(type: "bigint", nullable: false),
                    Grade_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolGrades_Grades_Grade_Id",
                        column: x => x.Grade_Id,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolGrades_Schools_School_Id",
                        column: x => x.School_Id,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassesOfSchool",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailNickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamsObjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolGrade_Id = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesOfSchool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassesOfSchool_SchoolGrades_SchoolGrade_Id",
                        column: x => x.SchoolGrade_Id,
                        principalTable: "SchoolGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectClasses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject_Id = table.Column<long>(type: "bigint", nullable: false),
                    Class_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectClasses_ClassesOfSchool_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "ClassesOfSchool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectClasses_Subjects_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalenderEvents_Id",
                table: "CalenderEvents",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassesOfSchool_Id",
                table: "ClassesOfSchool",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassesOfSchool_SchoolGrade_Id",
                table: "ClassesOfSchool",
                column: "SchoolGrade_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Id",
                table: "Grades",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operators_Id",
                table: "Operators",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGrades_Grade_Id",
                table: "SchoolGrades",
                column: "Grade_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGrades_Id",
                table: "SchoolGrades",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGrades_School_Id",
                table: "SchoolGrades",
                column: "School_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Id",
                table: "Schools",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Operator_Id",
                table: "Schools",
                column: "Operator_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_Class_Id",
                table: "SubjectClasses",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_Id",
                table: "SubjectClasses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClasses_Subject_Id",
                table: "SubjectClasses",
                column: "Subject_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Id",
                table: "Subjects",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_Event_Id",
                table: "UserEvents",
                column: "Event_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_Id",
                table: "UserEvents",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_User_Id",
                table: "UserEvents",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectClasses");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "ClassesOfSchool");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "CalenderEvents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SchoolGrades");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Operators");
        }
    }
}
