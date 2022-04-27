using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanDuck.Migrations
{
    public partial class addContributorUserIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Contributors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Contributors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_UserId1",
                table: "Contributors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributors_AspNetUsers_UserId1",
                table: "Contributors",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributors_AspNetUsers_UserId1",
                table: "Contributors");

            migrationBuilder.DropIndex(
                name: "IX_Contributors_UserId1",
                table: "Contributors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contributors");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Contributors");
        }
    }
}
