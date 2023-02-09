using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PindexBackend.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIssueLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "Categorization",
                columns: table => new
                {
                    CategorizationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorization", x => x.CategorizationId);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    IssueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Items_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategorizations",
                columns: table => new
                {
                    CategorizationsCategorizationId = table.Column<int>(type: "integer", nullable: false),
                    ItemsItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategorizations", x => new { x.CategorizationsCategorizationId, x.ItemsItemId });
                    table.ForeignKey(
                        name: "FK_ItemCategorizations_Categorization_CategorizationsCategoriz~",
                        column: x => x.CategorizationsCategorizationId,
                        principalTable: "Categorization",
                        principalColumn: "CategorizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCategorizations_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemIssues",
                columns: table => new
                {
                    IssuesIssueId = table.Column<int>(type: "integer", nullable: false),
                    ItemsItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemIssues", x => new { x.IssuesIssueId, x.ItemsItemId });
                    table.ForeignKey(
                        name: "FK_ItemIssues_Issue_IssuesIssueId",
                        column: x => x.IssuesIssueId,
                        principalTable: "Issue",
                        principalColumn: "IssueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemIssues_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategorizations_ItemsItemId",
                table: "ItemCategorizations",
                column: "ItemsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemIssues_ItemsItemId",
                table: "ItemIssues",
                column: "ItemsItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCategorizations");

            migrationBuilder.DropTable(
                name: "ItemIssues");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Categorization");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Items",
                type: "text",
                nullable: true);
        }
    }
}
