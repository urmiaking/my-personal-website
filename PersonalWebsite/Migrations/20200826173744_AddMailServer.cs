using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Migrations
{
    public partial class AddMailServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailServers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerAddress = table.Column<string>(nullable: true),
                    HostAddress = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailServers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MailServers",
                columns: new[] { "Id", "HostAddress", "Password", "Port", "ServerAddress", "Type" },
                values: new object[] { 1, "smtp.gmail.com", "MASOUD7559", 587, "masoud.xpress@gmail.com", null });

            migrationBuilder.UpdateData(
                table: "SiteAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResetPasswordCode",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 494, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 499, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 499, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 499, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 499, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 499, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 22, 7, 43, 499, DateTimeKind.Local).AddTicks(1598));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailServers");

            migrationBuilder.UpdateData(
                table: "SiteAdmins",
                keyColumn: "Id",
                keyValue: 1,
                column: "ResetPasswordCode",
                value: null);

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
    }
}
