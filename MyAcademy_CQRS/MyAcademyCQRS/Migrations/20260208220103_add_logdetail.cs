using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyCQRS.Migrations
{
    /// <inheritdoc />
    public partial class add_logdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Logs");
        }
    }
}
