using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAmbulantaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class dokIdPacId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorId",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_PacijentId",
                table: "Pregled");

            migrationBuilder.AlterColumn<string>(
                name: "PacijentId",
                table: "Pregled",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoktorId",
                table: "Pregled",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorId",
                table: "Pregled",
                column: "DoktorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_PacijentId",
                table: "Pregled",
                column: "PacijentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorId",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_AspNetUsers_PacijentId",
                table: "Pregled");

            migrationBuilder.AlterColumn<string>(
                name: "PacijentId",
                table: "Pregled",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoktorId",
                table: "Pregled",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_DoktorId",
                table: "Pregled",
                column: "DoktorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_AspNetUsers_PacijentId",
                table: "Pregled",
                column: "PacijentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
