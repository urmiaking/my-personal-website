using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Migrations
{
    public partial class AddSiteAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAdmins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SiteAdmins",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { 1, "masoud.xpress@gmail.com", "مسعود خدادادی", "f1ac294f56ceb706e90dd1719934c3ae444431483a2857bb001289f7d5acc0bb" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteAdmins");

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 643, DateTimeKind.Local).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 646, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 646, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 646, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 646, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 646, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 8, 26, 8, 11, 28, 646, DateTimeKind.Local).AddTicks(9071));
        }
    }
}
