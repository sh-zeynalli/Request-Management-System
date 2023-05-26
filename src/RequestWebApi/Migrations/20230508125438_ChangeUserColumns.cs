using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Users",
                type: "integer",
                nullable: true);
        }
    }
}
