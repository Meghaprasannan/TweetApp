using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class TweetAppNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "Users",
                newName: "Full_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "Users",
                newName: "First_Name");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
