using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VivaniBack.Migrations
{
    /// <inheritdoc />
    public partial class AddedShowInHometocontactMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInHome",
                table: "contactForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInHome",
                table: "contactForms");
        }
    }
}
