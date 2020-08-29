using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Migrations
{
    public partial class RefactorClientVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "ClientVisits");

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 848, DateTimeKind.Local).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9432));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "ClientVisits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 713, DateTimeKind.Local).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 716, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 716, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 716, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 716, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 716, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 29, 2, 24, 28, 716, DateTimeKind.Local).AddTicks(9675));
        }
    }
}
