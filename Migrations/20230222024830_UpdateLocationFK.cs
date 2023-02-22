using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PindexBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocationFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Items_LocationId",
                table: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Location",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Location_ItemId",
                table: "Location",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Items_ItemId",
                table: "Location",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Items_ItemId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_ItemId",
                table: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Location",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Items_LocationId",
                table: "Location",
                column: "LocationId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
