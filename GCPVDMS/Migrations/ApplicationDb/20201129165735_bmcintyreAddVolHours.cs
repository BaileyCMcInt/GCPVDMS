using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class bmcintyreAddVolHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PreferredContact = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    isVolunteer = table.Column<bool>(nullable: false),
                    isDonor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserHoursID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberOfHours = table.Column<decimal>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    VolunteeerGroupID = table.Column<int>(nullable: false),
                    VolunteerGroupID = table.Column<int>(nullable: true),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerHours_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VolunteerHours_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerHours_VolunteerGroups_VolunteerGroupID",
                        column: x => x.VolunteerGroupID,
                        principalTable: "VolunteerGroups",
                        principalColumn: "VolunteerGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerHours_ApplicationUserId",
                table: "VolunteerHours",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerHours_EventID",
                table: "VolunteerHours",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerHours_VolunteerGroupID",
                table: "VolunteerHours",
                column: "VolunteerGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerHours");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
