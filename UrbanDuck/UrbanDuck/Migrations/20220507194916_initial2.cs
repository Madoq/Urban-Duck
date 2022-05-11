using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanDuck.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_AddressId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Listings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_AddressId",
                table: "Listings",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Addresses_AddressId",
                table: "Listings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
