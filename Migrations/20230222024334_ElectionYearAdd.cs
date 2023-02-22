using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PindexBackend.Migrations
{
    /// <inheritdoc />
    public partial class ElectionYearAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectionDate",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "ElectionYear",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectionYear",
                table: "Items");

            migrationBuilder.AddColumn<DateTime>(
                name: "ElectionDate",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
