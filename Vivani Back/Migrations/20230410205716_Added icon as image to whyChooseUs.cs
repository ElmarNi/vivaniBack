using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaniBack.Migrations
{
    /// <inheritdoc />
    public partial class AddediconasimagetowhyChooseUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "whyChooseUs");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "whyChooseUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "whyChooseUs");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "whyChooseUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
