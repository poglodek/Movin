using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movin.Database.Migrations
{
    public partial class TestResultChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HostId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TestDate",
                table: "Results",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Results_HostId",
                table: "Results",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Hosts_HostId",
                table: "Results",
                column: "HostId",
                principalTable: "Hosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Hosts_HostId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_HostId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TestDate",
                table: "Results");
        }
    }
}
