using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduPortal.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Mentors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Mentors", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Mentors_Users_Id",
            //            column: x => x.Id,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Students",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Students", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Students_Users_Id",
            //            column: x => x.Id,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Courses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Duration = table.Column<int>(type: "int", nullable: false),
            //        MentorId = table.Column<int>(type: "int", nullable: true),
            //        StudentId = table.Column<int>(type: "int", nullable: true),
            //        StudentId1 = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Courses", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Courses_Mentors_MentorId",
            //            column: x => x.MentorId,
            //            principalTable: "Mentors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Courses_Students_StudentId",
            //            column: x => x.StudentId,
            //            principalTable: "Students",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Courses_Students_StudentId1",
            //            column: x => x.StudentId1,
            //            principalTable: "Students",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Materials",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CourseId = table.Column<int>(type: "int", nullable: true),
            //        MentorId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Materials", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Materials_Courses_CourseId",
            //            column: x => x.CourseId,
            //            principalTable: "Courses",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Materials_Mentors_MentorId",
            //            column: x => x.MentorId,
            //            principalTable: "Mentors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Articles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articles", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Articles_Materials_Id",
            //            column: x => x.Id,
            //            principalTable: "Materials",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DigitalBooks",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        NumberOfPages = table.Column<int>(type: "int", nullable: false),
            //        Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Year = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DigitalBooks", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DigitalBooks_Materials_Id",
            //            column: x => x.Id,
            //            principalTable: "Materials",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Skills",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Level = table.Column<int>(type: "int", nullable: false),
            //        MaterialId = table.Column<int>(type: "int", nullable: true),
            //        UserId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Skills", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Skills_Materials_MaterialId",
            //            column: x => x.MaterialId,
            //            principalTable: "Materials",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Skills_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VideoMaterials",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Length = table.Column<int>(type: "int", nullable: false),
            //        Quality = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VideoMaterials", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_VideoMaterials_Materials_Id",
            //            column: x => x.Id,
            //            principalTable: "Materials",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Courses_MentorId",
            //    table: "Courses",
            //    column: "MentorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Courses_StudentId",
            //    table: "Courses",
            //    column: "StudentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Courses_StudentId1",
            //    table: "Courses",
            //    column: "StudentId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Materials_CourseId",
            //    table: "Materials",
            //    column: "CourseId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Materials_MentorId",
            //    table: "Materials",
            //    column: "MentorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Skills_MaterialId",
            //    table: "Skills",
            //    column: "MaterialId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Skills_UserId",
            //    table: "Skills",
            //    column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "DigitalBooks");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "VideoMaterials");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
