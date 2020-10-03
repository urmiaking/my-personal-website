using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSampleCategories_Category_CategoryId",
                table: "WorkSampleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "WorkSamples",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Details",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Technologies",
                table: "Details",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Details",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Blogs",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogCategories",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AboutMe",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 656, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 657, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 657, DateTimeKind.Local).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 657, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 645, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 650, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 650, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 650, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 650, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 650, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 10, 4, 0, 43, 32, 650, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSampleCategories_Categories_CategoryId",
                table: "WorkSampleCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSampleCategories_Categories_CategoryId",
                table: "WorkSampleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "WorkSamples",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Technologies",
                table: "Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BlogCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AboutMe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 849, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(2931));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(3421));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(3542));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 850, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 842, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 846, DateTimeKind.Local).AddTicks(2839));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 846, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 846, DateTimeKind.Local).AddTicks(2949));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 846, DateTimeKind.Local).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 846, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "WorkSamples",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDateTime",
                value: new DateTime(2020, 9, 24, 22, 56, 57, 846, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSampleCategories_Category_CategoryId",
                table: "WorkSampleCategories",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
