using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasJohnLate.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecorderName = table.Column<string>(type: "TEXT", nullable: false),
                    EntryDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WasJohnLate = table.Column<bool>(type: "INTEGER", nullable: false),
                    EntryLocation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTime", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryTime");
        }
    }
}
