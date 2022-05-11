using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbie.Core.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Barbies");

            migrationBuilder.DropColumn(
                name: "IsFavourite",
                table: "Barbies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Barbies");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Categories",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "ShortDesc",
                table: "Barbies",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "LongDesc",
                table: "Barbies",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Barbies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Categories",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Barbies",
                newName: "ShortDesc");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Barbies",
                newName: "LongDesc");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Barbies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Barbies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavourite",
                table: "Barbies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Barbies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
