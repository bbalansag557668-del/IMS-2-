using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
