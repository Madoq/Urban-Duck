using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanDuck.Migrations
{
    public partial class addContributorUserIdFk4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                   name: "FK_Contributors_AspNetUsers_UserId",
                   table: "Contributors",
                   column: "UserId",
                   principalTable: "AspNetUsers",
                   principalColumn: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
