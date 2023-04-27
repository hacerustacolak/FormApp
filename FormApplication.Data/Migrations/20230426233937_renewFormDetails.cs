using Microsoft.EntityFrameworkCore.Migrations;

namespace FormApplication.Data.Migrations
{
    public partial class renewFormDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataType",
                table: "FormDetails");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "FormDetails");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "FormDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "FormDetails",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "FormDetails");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "FormDetails");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "FormDetails",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "FormDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
