using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cf.Dotnet.EntityFramework.Parte2Extra.Migrations
{
    /// <inheritdoc />
    public partial class VersionToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Orders",
                type: "timestamp",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Orders");
        }
    }
}
