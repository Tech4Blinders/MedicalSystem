using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalSystem.DataAccessLayer.Migrations
{
    public partial class UpdateDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "");

            migrationBuilder.UpdateData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctor");
        }
    }
}
