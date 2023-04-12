using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaniBack.Migrations
{
    /// <inheritdoc />
    public partial class addedisReponsedtoContactForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResponsed",
                table: "contactForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResponsed",
                table: "contactForms");
        }
    }
}
