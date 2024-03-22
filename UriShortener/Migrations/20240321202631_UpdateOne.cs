using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UriShortener.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UriDetails_UniqueCode",
                table: "UriDetails");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "UriDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "UriDetails",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UriDetails_UniqueCode",
                table: "UriDetails",
                column: "UniqueCode");
        }
    }
}
