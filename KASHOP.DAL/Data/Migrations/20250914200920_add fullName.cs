using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KASHOP.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addfullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");
        }
    }
}
