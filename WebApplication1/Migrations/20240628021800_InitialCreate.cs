using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying", nullable: false),
                    pekerjaan = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mst_user_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MstOffice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameDeptHead = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_profile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    nama_lengkap = table.Column<string>(type: "character varying", nullable: true),
                    alamat = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("mst_profile_pk", x => x.id);
                    table.ForeignKey(
                        name: "mst_profile_mst_user_fk",
                        column: x => x.user_id,
                        principalTable: "mst_user",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "MstOffice",
                columns: new[] { "Id", "Alamat", "NameDeptHead" },
                values: new object[,]
                {
                    { 1, "Jogja", "Latief" },
                    { 2, "Monjali", "Irfan" },
                    { 3, "Doc", "Sya" }
                });

            migrationBuilder.CreateIndex(
                name: "mst_profile_unique",
                table: "mst_profile",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "mst_user_unique",
                table: "mst_user",
                column: "user_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_profile");

            migrationBuilder.DropTable(
                name: "MstOffice");

            migrationBuilder.DropTable(
                name: "mst_user");
        }
    }
}
