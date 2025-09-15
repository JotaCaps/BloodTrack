using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodTrack.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Logradouro",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Address_Logradouro",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Donors");
        }
    }
}
