using Microsoft.EntityFrameworkCore.Migrations;

namespace News.DAL.Migrations
{
    public partial class upatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Newss",
                newName: "Photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Newss",
                newName: "Images");
        }
    }
}
