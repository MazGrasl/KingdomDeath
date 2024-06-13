using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingdomDeathAPI.Migrations
{
    /// <inheritdoc />
    public partial class SettlementStorageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settlements",
                schema: "KD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettlementGearStorageItem",
                schema: "KD",
                columns: table => new
                {
                    SettlementId = table.Column<int>(type: "int", nullable: false),
                    GearId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementGearStorageItem", x => new { x.SettlementId, x.GearId });
                    table.ForeignKey(
                        name: "FK_SettlementGearStorageItem_Gears_GearId",
                        column: x => x.GearId,
                        principalSchema: "KD",
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettlementGearStorageItem_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalSchema: "KD",
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettlementResourceStorageItem",
                schema: "KD",
                columns: table => new
                {
                    SettlementId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementResourceStorageItem", x => new { x.SettlementId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_SettlementResourceStorageItem_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "KD",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SettlementResourceStorageItem_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalSchema: "KD",
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettlementGearStorageItem_GearId",
                schema: "KD",
                table: "SettlementGearStorageItem",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementResourceStorageItem_ResourceId",
                schema: "KD",
                table: "SettlementResourceStorageItem",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettlementGearStorageItem",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "SettlementResourceStorageItem",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "Settlements",
                schema: "KD");
        }
    }
}
