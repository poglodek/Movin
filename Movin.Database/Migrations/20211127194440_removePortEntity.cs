using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movin.Database.Migrations
{
    public partial class removePortEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Hosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Hosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Port",
                table: "Hosts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Hosts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Hosts");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Hosts");

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostId = table.Column<int>(type: "int", nullable: true),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Ports_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ports_HostId",
                table: "Ports",
                column: "HostId");
        }
    }
}
