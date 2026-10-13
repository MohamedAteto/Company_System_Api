using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company_System_Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "New York", "Human Resources" },
                    { 2, "London", "Finance" },
                    { 3, "San Francisco", "IT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin1@gmail.com", "admin123", "Admin", "admin" },
                    { 2, "member1@gmail.com", "member123", "Member", "member" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FullName", "HireDate", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "mohamedhassan@gmail.com", "Mohamed Hassan", new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 12323m },
                    { 2, 2, "malakmostafa@gmail.com", "Malak mostafa", new DateTime(2023, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000m }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "DepartmentId", "Description", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 50000m, 1, "Description for Project A", "Project A", new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 75000m, 2, "Description for Project B", "Project B", new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "id", "AssignedDate", "AssignedRole", "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developer", 1, 1 },
                    { 2, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tester", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId",
                table: "EmployeeProjects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
