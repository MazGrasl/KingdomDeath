using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KingdomDeathAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedVerminResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "KD",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Expansion",
                schema: "KD",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "KD",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Expansion",
                schema: "KD",
                table: "Gears",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "KD",
                table: "Gears",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "KD",
                table: "Resources",
                columns: new[] { "Id", "Category", "Expansion", "Name" },
                values: new object[,]
                {
                    { 149, "Vermin Resource", "Core Game", "Crab Spider" },
                    { 150, "Vermin Resource", "Core Game", "Cyclops Fly" },
                    { 151, "Vermin Resource", "Core Game", "Hissing Cockroach" },
                    { 152, "Vermin Resource", "Core Game", "Lonely Ant" },
                    { 153, "Vermin Resource", "Core Game", "Nightmare Tick" },
                    { 154, "Vermin Resource", "Core Game", "Sword Beetle" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "KD",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                schema: "KD",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                schema: "KD",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                schema: "KD",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                schema: "KD",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                schema: "KD",
                table: "Resources",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "KD",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Expansion",
                schema: "KD",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "KD",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Expansion",
                schema: "KD",
                table: "Gears",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                schema: "KD",
                table: "Gears",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
