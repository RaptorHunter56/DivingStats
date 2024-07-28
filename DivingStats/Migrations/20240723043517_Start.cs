using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivingStats.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Divers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dives",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Board = table.Column<decimal>(type: "TEXT", nullable: false),
                    DD = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dives", x => new { x.ID, x.Board });
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    CompetitionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rounds_Competitions_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualDives",
                columns: table => new
                {
                    DiverID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoundID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoundNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    DiveID = table.Column<string>(type: "TEXT", nullable: false),
                    DiveBoard = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualDives", x => new { x.DiverID, x.RoundID, x.RoundNumber });
                    table.ForeignKey(
                        name: "FK_IndividualDives_Divers_DiverID",
                        column: x => x.DiverID,
                        principalTable: "Divers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualDives_Dives_DiveID_DiveBoard",
                        columns: x => new { x.DiveID, x.DiveBoard },
                        principalTable: "Dives",
                        principalColumns: new[] { "ID", "Board" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualDives_Rounds_RoundID",
                        column: x => x.RoundID,
                        principalTable: "Rounds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDives_DiveID_DiveBoard",
                table: "IndividualDives",
                columns: new[] { "DiveID", "DiveBoard" });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualDives_RoundID",
                table: "IndividualDives",
                column: "RoundID");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_CompetitionID",
                table: "Rounds",
                column: "CompetitionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualDives");

            migrationBuilder.DropTable(
                name: "Divers");

            migrationBuilder.DropTable(
                name: "Dives");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
