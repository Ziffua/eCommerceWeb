using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceWeb.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewProduct",
                table: "NewProduct");

            migrationBuilder.RenameTable(
                name: "NewProduct",
                newName: "NewProductVM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewProductVM",
                table: "NewProductVM",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewProductVM",
                table: "NewProductVM");

            migrationBuilder.RenameTable(
                name: "NewProductVM",
                newName: "NewProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewProduct",
                table: "NewProduct",
                column: "id");
        }
    }
}
