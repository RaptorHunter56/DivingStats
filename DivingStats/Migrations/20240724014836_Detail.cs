using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivingStats.Migrations
{
    public partial class Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Divers",
                newName: "Nationality");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Rounds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Rounds",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Divers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Divers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Divers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Competitions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Competitions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Competitions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Competitions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Divers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Divers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Divers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Divers",
                newName: "Name");
        }
    }
}
