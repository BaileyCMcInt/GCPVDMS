using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class dfugle_registrationconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventID",
                table: "EventRegistrations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventRegistrations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventID_UserId",
                table: "EventRegistrations",
                columns: new[] { "EventID", "UserId" },
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventID_UserId",
                table: "EventRegistrations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventID",
                table: "EventRegistrations",
                column: "EventID");
        }
    }
}
