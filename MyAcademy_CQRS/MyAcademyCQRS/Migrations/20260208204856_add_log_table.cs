using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyCQRS.Migrations
{
    /// <inheritdoc />
    public partial class add_log_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // --- HATA VEREN KISMI SİLDİK/YORUMA ALDIK ---
            // migrationBuilder.AddColumn<string>(
            //    name: "CategoryName",
            //    table: "News",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            // --- SADECE LOG TABLOSUNU OLUŞTURUYORUZ ---
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            // Down metodunda da CategoryName silme işlemini kaldırıyoruz ki
            // Migration geri alınırsa var olan sütunu silmesin.
        }
    }
}
