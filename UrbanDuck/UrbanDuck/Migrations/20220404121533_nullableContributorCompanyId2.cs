using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrbanDuck.Migrations
{
    public partial class nullableContributorCompanyId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributors_Companies_CompanyId",
                table: "Contributors");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Contributors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributors_Companies_CompanyId",
                table: "Contributors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributors_Companies_CompanyId",
                table: "Contributors");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Contributors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributors_Companies_CompanyId",
                table: "Contributors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
