using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CreateMstOffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MstOffice",
                table: "MstOffice");

            migrationBuilder.RenameTable(
                name: "MstOffice",
                newName: "mst_office");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mst_office",
                table: "mst_office",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_mst_office",
                table: "mst_office");

            migrationBuilder.RenameTable(
                name: "mst_office",
                newName: "MstOffice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstOffice",
                table: "MstOffice",
                column: "Id");
        }
    }
}
