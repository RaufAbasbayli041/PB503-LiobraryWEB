using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWEB.Migrations
{
    /// <inheritdoc />
    public partial class library3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Publishers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Delated",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Publishers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Delated",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BookCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Delated",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "BookCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Delated",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Authors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AuthorContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Delated",
                table: "AuthorContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AuthorContacts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Delated",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Delated",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "Delated",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Delated",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AuthorContacts");

            migrationBuilder.DropColumn(
                name: "Delated",
                table: "AuthorContacts");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AuthorContacts");
        }
    }
}
