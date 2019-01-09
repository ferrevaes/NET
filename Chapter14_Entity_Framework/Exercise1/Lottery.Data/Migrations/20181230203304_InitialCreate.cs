using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lottery.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LotteryGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    NumberOfNumbersInADraw = table.Column<int>(nullable: false),
                    MaximumNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LotteryGameId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Draws_LotteryGames_LotteryGameId",
                        column: x => x.LotteryGameId,
                        principalTable: "LotteryGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrawNumber",
                columns: table => new
                {
                    DrawId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawNumber", x => new { x.DrawId, x.Number });
                    table.ForeignKey(
                        name: "FK_DrawNumber_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LotteryGames",
                columns: new[] { "Id", "MaximumNumber", "Name", "NumberOfNumbersInADraw" },
                values: new object[] { 1, 45, "National Lottery", 6 });

            migrationBuilder.InsertData(
                table: "LotteryGames",
                columns: new[] { "Id", "MaximumNumber", "Name", "NumberOfNumbersInADraw" },
                values: new object[] { 2, 70, "Keeno", 20 });

            migrationBuilder.CreateIndex(
                name: "IX_Draws_LotteryGameId",
                table: "Draws",
                column: "LotteryGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawNumber");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropTable(
                name: "LotteryGames");
        }
    }
}
