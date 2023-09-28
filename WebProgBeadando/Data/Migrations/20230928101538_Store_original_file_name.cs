using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgBeadando.Data.Migrations
{
    /// <inheritdoc />
    public partial class Storeoriginalfilename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "Files");
        }
    }
}
