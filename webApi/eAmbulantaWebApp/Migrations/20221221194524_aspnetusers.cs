using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAmbulantaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class aspnetusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bolest_AspNetUsers_PacijentId",
                table: "Bolest");

            migrationBuilder.AlterColumn<string>(
                name: "PacijentId",
                table: "Bolest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bolest_AspNetUsers_PacijentId",
                table: "Bolest",
                column: "PacijentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bolest_AspNetUsers_PacijentId",
                table: "Bolest");

            migrationBuilder.AlterColumn<string>(
                name: "PacijentId",
                table: "Bolest",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Bolest_AspNetUsers_PacijentId",
                table: "Bolest",
                column: "PacijentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
