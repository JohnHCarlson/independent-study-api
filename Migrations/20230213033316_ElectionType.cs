using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PindexBackend.Migrations
{
    /// <inheritdoc />
    public partial class ElectionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ElectionType",
                table: "Items",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectionType",
                table: "Items");
        }
    }
}
