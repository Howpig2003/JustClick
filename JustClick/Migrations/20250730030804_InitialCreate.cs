using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustClick.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClickCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalClickCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LastClickTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickCounters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClickCounters_Id",
                table: "ClickCounters",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClickCounters");
        }
    }
}
