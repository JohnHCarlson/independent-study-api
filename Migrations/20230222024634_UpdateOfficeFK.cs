using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PindexBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfficeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Office_Items_OfficeId",
                table: "Office");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "Office",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Office_ItemId",
                table: "Office",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Office_Items_ItemId",
                table: "Office",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Office_Items_ItemId",
                table: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Office_ItemId",
                table: "Office");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "Office",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Office_Items_OfficeId",
                table: "Office",
                column: "OfficeId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
