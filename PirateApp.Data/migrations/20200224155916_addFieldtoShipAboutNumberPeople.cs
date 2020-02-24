using Microsoft.EntityFrameworkCore.Migrations;

namespace PirateApp.Data.Migrations
{
    public partial class addFieldtoShipAboutNumberPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HowManyPeopleCanTake",
                table: "Ship",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowManyPeopleCanTake",
                table: "Ship");
        }
    }
}
