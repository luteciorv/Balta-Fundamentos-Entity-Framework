using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class User_Add_Github : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Github",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 30, 14, 51, 58, 525, DateTimeKind.Utc).AddTicks(4203),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 11, 30, 14, 40, 33, 834, DateTimeKind.Utc).AddTicks(8352));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Github",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Post",
                type: "SMALLDATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 30, 14, 40, 33, 834, DateTimeKind.Utc).AddTicks(8352),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldDefaultValue: new DateTime(2023, 11, 30, 14, 51, 58, 525, DateTimeKind.Utc).AddTicks(4203));
        }
    }
}
