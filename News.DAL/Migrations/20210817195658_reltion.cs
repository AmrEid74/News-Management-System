using Microsoft.EntityFrameworkCore.Migrations;

namespace News.DAL.Migrations
{
    public partial class reltion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorId",
                table: "Newss",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Newss_EditorId",
                table: "Newss",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AdminId",
                table: "Categories",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Admin_AdminId",
                table: "Categories",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Newss_Editor_EditorId",
                table: "Newss",
                column: "EditorId",
                principalTable: "Editor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Admin_AdminId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Newss_Editor_EditorId",
                table: "Newss");

            migrationBuilder.DropIndex(
                name: "IX_Newss_EditorId",
                table: "Newss");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AdminId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "Newss");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Categories");
        }
    }
}
