using Microsoft.EntityFrameworkCore.Migrations;

namespace music.Migrations
{
    public partial class SeedSongsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "Language", "Title" },
                values: new object[] { 1, "3:30", "English", "Eye of the tiger" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "Language", "Title" },
                values: new object[] { 2, "3:23", "Español", "Despacito" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
