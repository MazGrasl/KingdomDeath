using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingdomDeathAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelationClassesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GearTag_Gears_GearsId",
                schema: "KD",
                table: "GearTag");

            migrationBuilder.DropForeignKey(
                name: "FK_GearTag_Tags_TagsId",
                schema: "KD",
                table: "GearTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTag_Resources_ResourcesId",
                schema: "KD",
                table: "ResourceTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceTag_Tags_TagsId",
                schema: "KD",
                table: "ResourceTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTag",
                schema: "KD",
                table: "ResourceTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearTag",
                schema: "KD",
                table: "GearTag");

            migrationBuilder.RenameTable(
                name: "ResourceTag",
                schema: "KD",
                newName: "ResourceTags",
                newSchema: "KD");

            migrationBuilder.RenameTable(
                name: "GearTag",
                schema: "KD",
                newName: "GearTags",
                newSchema: "KD");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceTag_TagsId",
                schema: "KD",
                table: "ResourceTags",
                newName: "IX_ResourceTags_TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_GearTag_TagsId",
                schema: "KD",
                table: "GearTags",
                newName: "IX_GearTags_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTags",
                schema: "KD",
                table: "ResourceTags",
                columns: new[] { "ResourcesId", "TagsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearTags",
                schema: "KD",
                table: "GearTags",
                columns: new[] { "GearsId", "TagsId" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTags",
                schema: "KD",
                table: "ResourceTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GearTags",
                schema: "KD",
                table: "GearTags");

            migrationBuilder.RenameTable(
                name: "ResourceTags",
                schema: "KD",
                newName: "ResourceTag",
                newSchema: "KD");

            migrationBuilder.RenameTable(
                name: "GearTags",
                schema: "KD",
                newName: "GearTag",
                newSchema: "KD");

            migrationBuilder.RenameIndex(
                name: "IX_ResourceTags_TagsId",
                schema: "KD",
                table: "ResourceTag",
                newName: "IX_ResourceTag_TagsId");

            migrationBuilder.RenameIndex(
                name: "IX_GearTags_TagsId",
                schema: "KD",
                table: "GearTag",
                newName: "IX_GearTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTag",
                schema: "KD",
                table: "ResourceTag",
                columns: new[] { "ResourcesId", "TagsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GearTag",
                schema: "KD",
                table: "GearTag",
                columns: new[] { "GearsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GearTag_Gears_GearsId",
                schema: "KD",
                table: "GearTag",
                column: "GearsId",
                principalSchema: "KD",
                principalTable: "Gears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GearTag_Tags_TagsId",
                schema: "KD",
                table: "GearTag",
                column: "TagsId",
                principalSchema: "KD",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTag_Resources_ResourcesId",
                schema: "KD",
                table: "ResourceTag",
                column: "ResourcesId",
                principalSchema: "KD",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceTag_Tags_TagsId",
                schema: "KD",
                table: "ResourceTag",
                column: "TagsId",
                principalSchema: "KD",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
