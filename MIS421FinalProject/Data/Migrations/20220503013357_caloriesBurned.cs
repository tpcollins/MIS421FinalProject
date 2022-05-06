using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS421FinalProject.Data.Migrations
{
    public partial class caloriesBurned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "caloriesBurned",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "caloriesBurned",
                table: "Exercise");
        }
    }
}
