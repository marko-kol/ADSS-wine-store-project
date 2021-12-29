using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkoWineStore.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "deliveryAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mobilePhone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mobilePhone",
                table: "AspNetUsers");
        }
    }
}
