using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWEB.Migrations
{
    /// <inheritdoc />
    public partial class _323 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Delated",
                table: "Publishers",
                newName: "IsDelated");

            migrationBuilder.RenameColumn(
                name: "Delated",
                table: "Books",
                newName: "IsDelated");

            migrationBuilder.RenameColumn(
                name: "Delated",
                table: "BookCategories",
                newName: "IsDelated");

            migrationBuilder.RenameColumn(
                name: "Delated",
                table: "Authors",
                newName: "IsDelated");

            migrationBuilder.RenameColumn(
                name: "Delated",
                table: "AuthorContacts",
                newName: "IsDelated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelated",
                table: "Publishers",
                newName: "Delated");

            migrationBuilder.RenameColumn(
                name: "IsDelated",
                table: "Books",
                newName: "Delated");

            migrationBuilder.RenameColumn(
                name: "IsDelated",
                table: "BookCategories",
                newName: "Delated");

            migrationBuilder.RenameColumn(
                name: "IsDelated",
                table: "Authors",
                newName: "Delated");

            migrationBuilder.RenameColumn(
                name: "IsDelated",
                table: "AuthorContacts",
                newName: "Delated");
        }
    }
}
