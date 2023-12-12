using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorLinq.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => x.eid);
                });

            migrationBuilder.CreateTable(
                name: "Cla",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roomNo = table.Column<int>(type: "int", nullable: false),
                    facultyfid = table.Column<int>(type: "int", nullable: true),
                    Enrolledeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cla", x => x.cid);
                    table.ForeignKey(
                        name: "FK_Cla_Enrolled_Enrolledeid",
                        column: x => x.Enrolledeid,
                        principalTable: "Enrolled",
                        principalColumn: "eid");
                });

            migrationBuilder.CreateTable(
                name: "studen",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classcid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studen", x => x.sid);
                    table.ForeignKey(
                        name: "FK_studen_Cla_Classcid",
                        column: x => x.Classcid,
                        principalTable: "Cla",
                        principalColumn: "cid");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledStudent",
                columns: table => new
                {
                    enrollseid = table.Column<int>(type: "int", nullable: false),
                    studentssid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledStudent", x => new { x.enrollseid, x.studentssid });
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_Enrolled_enrollseid",
                        column: x => x.enrollseid,
                        principalTable: "Enrolled",
                        principalColumn: "eid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_studen_studentssid",
                        column: x => x.studentssid,
                        principalTable: "studen",
                        principalColumn: "sid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculti",
                columns: table => new
                {
                    fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    depid = table.Column<int>(type: "int", nullable: false),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrolleid = table.Column<int>(type: "int", nullable: true),
                    Studentsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculti", x => x.fid);
                    table.ForeignKey(
                        name: "FK_Faculti_Enrolled_enrolleid",
                        column: x => x.enrolleid,
                        principalTable: "Enrolled",
                        principalColumn: "eid");
                    table.ForeignKey(
                        name: "FK_Faculti_studen_Studentsid",
                        column: x => x.Studentsid,
                        principalTable: "studen",
                        principalColumn: "sid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cla_Enrolledeid",
                table: "Cla",
                column: "Enrolledeid");

            migrationBuilder.CreateIndex(
                name: "IX_Cla_facultyfid",
                table: "Cla",
                column: "facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledStudent_studentssid",
                table: "EnrolledStudent",
                column: "studentssid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculti_enrolleid",
                table: "Faculti",
                column: "enrolleid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculti_Studentsid",
                table: "Faculti",
                column: "Studentsid");

            migrationBuilder.CreateIndex(
                name: "IX_studen_Classcid",
                table: "studen",
                column: "Classcid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cla_Faculti_facultyfid",
                table: "Cla",
                column: "facultyfid",
                principalTable: "Faculti",
                principalColumn: "fid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cla_Enrolled_Enrolledeid",
                table: "Cla");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculti_Enrolled_enrolleid",
                table: "Faculti");

            migrationBuilder.DropForeignKey(
                name: "FK_Cla_Faculti_facultyfid",
                table: "Cla");

            migrationBuilder.DropTable(
                name: "EnrolledStudent");

            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "Faculti");

            migrationBuilder.DropTable(
                name: "studen");

            migrationBuilder.DropTable(
                name: "Cla");
        }
    }
}
