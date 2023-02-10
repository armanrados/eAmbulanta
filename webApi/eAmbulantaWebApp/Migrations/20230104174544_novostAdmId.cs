using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAmbulantaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class novostAdmId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novost_AspNetUsers_AdministratorId",
                table: "Novost");

            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Novost",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Novost_AspNetUsers_AdministratorId",
                table: "Novost",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novost_AspNetUsers_AdministratorId",
                table: "Novost");

            migrationBuilder.AlterColumn<string>(
                name: "AdministratorId",
                table: "Novost",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Novost_AspNetUsers_AdministratorId",
                table: "Novost",
                column: "AdministratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
