using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Migrations
{
    public partial class AddResetPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordCode",
                table: "SiteAdmins",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 48, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 54, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 54, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 54, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 54, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 54, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 21, 54, 31, 54, DateTimeKind.Local).AddTicks(9488));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordCode",
                table: "SiteAdmins");

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 182, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 185, DateTimeKind.Local).AddTicks(5666));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 185, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 185, DateTimeKind.Local).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 185, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 185, DateTimeKind.Local).AddTicks(5746));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 18, 40, 2, 185, DateTimeKind.Local).AddTicks(5750));
        }
    }
}
