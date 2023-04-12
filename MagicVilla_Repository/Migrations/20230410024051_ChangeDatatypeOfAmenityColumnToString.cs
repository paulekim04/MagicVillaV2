using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatatypeOfAmenityColumnToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Amenity",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amenity",
                table: "Villas",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
