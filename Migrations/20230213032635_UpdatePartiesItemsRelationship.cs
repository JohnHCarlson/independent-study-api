using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PindexBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePartiesItemsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemParty");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Parties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_ItemId",
                table: "Parties",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Items_ItemId",
                table: "Parties",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Items_ItemId",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Parties_ItemId",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Parties");

            migrationBuilder.CreateTable(
                name: "ItemParty",
                columns: table => new
                {
                    ItemsItemId = table.Column<int>(type: "integer", nullable: false),
                    PartiesPartyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemParty", x => new { x.ItemsItemId, x.PartiesPartyId });
                    table.ForeignKey(
                        name: "FK_ItemParty_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemParty_Parties_PartiesPartyId",
                        column: x => x.PartiesPartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemParty_PartiesPartyId",
                table: "ItemParty",
                column: "PartiesPartyId");
        }
    }
}
