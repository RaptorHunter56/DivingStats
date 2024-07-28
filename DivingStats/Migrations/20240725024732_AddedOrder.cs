using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivingStats.Migrations
{
    public partial class AddedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "IndividualDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "IndividualDives");
        }
    }
}
