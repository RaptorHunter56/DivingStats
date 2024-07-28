using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivingStats.Migrations
{
    public partial class ChangeScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Judge1ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Judge2ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Judge3ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Judge4ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Judge5ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Judge6ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Judge7ID",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Value1",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value2",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value3",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value4",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value5",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value6",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Value7",
                table: "IndividualDives",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Judge1ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Judge2ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Judge3ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Judge4ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Judge5ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Judge6ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Judge7ID",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value1",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value2",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value3",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value4",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value5",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value6",
                table: "IndividualDives");

            migrationBuilder.DropColumn(
                name: "Value7",
                table: "IndividualDives");
        }
    }
}
