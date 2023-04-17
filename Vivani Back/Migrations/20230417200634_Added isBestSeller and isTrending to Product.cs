using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaniBack.Migrations
{
    /// <inheritdoc />
    public partial class AddedisBestSellerandisTrendingtoProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBestSeller",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrendingProduct",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBestSeller",
                table: "products");

            migrationBuilder.DropColumn(
                name: "IsTrendingProduct",
                table: "products");
        }
    }
}
