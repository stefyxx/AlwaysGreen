using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlwaysGreen.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
