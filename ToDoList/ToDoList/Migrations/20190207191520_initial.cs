using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksToDo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    TimeRequired = table.Column<TimeSpan>(nullable: false),
                    Day = table.Column<Guid>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    DayTaskId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksToDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksToDo_DayTasks_DayTaskId",
                        column: x => x.DayTaskId,
                        principalTable: "DayTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasksToDo_DayTaskId",
                table: "TasksToDo",
                column: "DayTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasksToDo");

            migrationBuilder.DropTable(
                name: "DayTasks");
        }
    }
}
