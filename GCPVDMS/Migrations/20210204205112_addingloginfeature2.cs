using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCPVDMS.Migrations
{
    public partial class addingloginfeature2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                schema: "Identity",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                schema: "Identity",
                table: "User",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FirstTimeLogin",
                schema: "Identity",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstTimeLogin",
                schema: "Identity",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                schema: "Identity",
                table: "User",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
