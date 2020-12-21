using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations
{
    public partial class approvalStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                schema: "Identity",
                table: "User");
        }
    }
}
