using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingdomDeathAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelationClassesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearTags_Gears_GearsId",
                schema: "KD",
                table: "GearTags");

            migrationBuilder.DropForeignKey(
                name: "FK_GearTags_Tags_TagsId",
                schema: "KD",
                table: "GearTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTags_Resources_ResourcesId",
                schema: "KD",
                table: "ResourceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTags_Tags_TagsId",
                schema: "KD",
                table: "ResourceTags");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                schema: "KD",
                table: "ResourceTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "ResourcesId",
                schema: "KD",
                table: "ResourceTags",
                newName: "ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceTags_TagsId",
                schema: "KD",
                table: "ResourceTags",
                newName: "IX_ResourceTags_TagId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                schema: "KD",
                table: "GearTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "GearsId",
                schema: "KD",
                table: "GearTags",
                newName: "GearId");

            migrationBuilder.RenameIndex(
                name: "IX_GearTags_TagsId",
                schema: "KD",
                table: "GearTags",
                newName: "IX_GearTags_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_GearTags_Gears_GearId",
                schema: "KD",
                table: "GearTags",
                column: "GearId",
                principalSchema: "KD",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GearTags_Tags_TagId",
                schema: "KD",
                table: "GearTags",
                column: "TagId",
                principalSchema: "KD",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTags_Resources_ResourceId",
                schema: "KD",
                table: "ResourceTags",
                column: "ResourceId",
                principalSchema: "KD",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTags_Tags_TagId",
                schema: "KD",
                table: "ResourceTags",
                column: "TagId",
                principalSchema: "KD",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearTags_Gears_GearId",
                schema: "KD",
                table: "GearTags");

            migrationBuilder.DropForeignKey(
                name: "FK_GearTags_Tags_TagId",
                schema: "KD",
                table: "GearTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTags_Resources_ResourceId",
                schema: "KD",
                table: "ResourceTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTags_Tags_TagId",
                schema: "KD",
                table: "ResourceTags");

            migrationBuilder.RenameColumn(
                name: "TagId",
                schema: "KD",
                table: "ResourceTags",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                schema: "KD",
                table: "ResourceTags",
                newName: "ResourcesId");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceTags_TagId",
                schema: "KD",
                table: "ResourceTags",
                newName: "IX_ResourceTags_TagsId");

            migrationBuilder.RenameColumn(
                name: "TagId",
                schema: "KD",
                table: "GearTags",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "GearId",
                schema: "KD",
                table: "GearTags",
                newName: "GearsId");

            migrationBuilder.RenameIndex(
                name: "IX_GearTags_TagId",
                schema: "KD",
                table: "GearTags",
                newName: "IX_GearTags_TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GearTags_Gears_GearsId",
                schema: "KD",
                table: "GearTags",
                column: "GearsId",
                principalSchema: "KD",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GearTags_Tags_TagsId",
                schema: "KD",
                table: "GearTags",
                column: "TagsId",
                principalSchema: "KD",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTags_Resources_ResourcesId",
                schema: "KD",
                table: "ResourceTags",
                column: "ResourcesId",
                principalSchema: "KD",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTags_Tags_TagsId",
                schema: "KD",
                table: "ResourceTags",
                column: "TagsId",
                principalSchema: "KD",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
