using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentScheduling1.Migrations
{
    /// <inheritdoc />
    public partial class addingmoreuserdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedTo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicalId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "assignMentStatus",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MedicalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "assignMentStatus",
                table: "AspNetUsers");
        }
    }
}
