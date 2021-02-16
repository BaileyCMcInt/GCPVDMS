using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations.ApplicationDb
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    CountyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyName = table.Column<string>(nullable: true),
                    CountyState = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.CountyID);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    DriveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.DriveID);
                });

            migrationBuilder.CreateTable(
                name: "GCPTasks",
                columns: table => new
                {
                    GCPTaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCPTasks", x => x.GCPTaskID);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerGroups",
                columns: table => new
                {
                    VolunteerGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerGroups", x => x.VolunteerGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    CountyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Counties_CountyID",
                        column: x => x.CountyID,
                        principalTable: "Counties",
                        principalColumn: "CountyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    EventTitle = table.Column<string>(nullable: false),
                    EventDescription = table.Column<string>(nullable: true),
                    POCName = table.Column<string>(nullable: true),
                    POCPhone = table.Column<string>(nullable: true),
                    POCEmail = table.Column<string>(nullable: true),
                    isEventActive = table.Column<bool>(nullable: false),
                    NumVolunteersNeeded = table.Column<int>(nullable: false),
                    NumVolunteersSignedUp = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRegistrations",
                columns: table => new
                {
                    EventRegistrationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistrations", x => x.EventRegistrationID);
                    table.ForeignKey(
                        name: "FK_EventRegistrations_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GCPEventTasks",
                columns: table => new
                {
                    GCPEventTaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(nullable: false),
                    GCPTaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCPEventTasks", x => x.GCPEventTaskID);
                    table.ForeignKey(
                        name: "FK_GCPEventTasks_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GCPEventTasks_GCPTasks_GCPTaskID",
                        column: x => x.GCPTaskID,
                        principalTable: "GCPTasks",
                        principalColumn: "GCPTaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerHours",
                columns: table => new
                {
                    VolunteerHourID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberOfHours = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VolunteerGroupID = table.Column<int>(nullable: true),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerHours", x => x.VolunteerHourID);
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
                name: "IX_EventRegistrations_EventID",
                table: "EventRegistrations",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationID",
                table: "Events",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_GCPEventTasks_EventID",
                table: "GCPEventTasks",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_GCPEventTasks_GCPTaskID",
                table: "GCPEventTasks",
                column: "GCPTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountyID",
                table: "Locations",
                column: "CountyID");

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
                name: "Drives");

            migrationBuilder.DropTable(
                name: "EventRegistrations");

            migrationBuilder.DropTable(
                name: "GCPEventTasks");

            migrationBuilder.DropTable(
                name: "VolunteerHours");

            migrationBuilder.DropTable(
                name: "GCPTasks");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "VolunteerGroups");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Counties");
        }
    }
}
