using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAmbulantaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specijalizacija",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specijalizacija", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorIme = table.Column<string>(name: "Doktor_Ime", type: "nvarchar(max)", nullable: true),
                    DoktorPrezime = table.Column<string>(name: "Doktor_Prezime", type: "nvarchar(max)", nullable: true),
                    Titula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecijalizacijaDoktorid = table.Column<int>(type: "int", nullable: true),
                    MedicinskaSestraTehnicarIme = table.Column<string>(name: "MedicinskaSestraTehnicar_Ime", type: "nvarchar(max)", nullable: true),
                    MedicinskaSestraTehnicarPrezime = table.Column<string>(name: "MedicinskaSestraTehnicar_Prezime", type: "nvarchar(max)", nullable: true),
                    Obrazovanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacijentIme = table.Column<string>(name: "Pacijent_Ime", type: "nvarchar(max)", nullable: true),
                    PacijentPrezime = table.Column<string>(name: "Pacijent_Prezime", type: "nvarchar(max)", nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    datumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LokacijaID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Lokacija_LokacijaID",
                        column: x => x.LokacijaID,
                        principalTable: "Lokacija",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Specijalizacija_SpecijalizacijaDoktorid",
                        column: x => x.SpecijalizacijaDoktorid,
                        principalTable: "Specijalizacija",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bolest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICDKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacijentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolest_AspNetUsers_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JavnaNabavka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pdfFajl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdministratorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnaNabavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JavnaNabavka_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lijek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odobreno = table.Column<bool>(type: "bit", nullable: false),
                    Kolicina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PacijentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lijek_AspNetUsers_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lijek_AspNetUsers_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicinskiTretman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Obavljen = table.Column<bool>(type: "bit", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIVrijemePropisa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIVrijemeObavljanja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicinskaSestraTehnicarId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PacijentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinskiTretman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinskiTretman_AspNetUsers_MedicinskaSestraTehnicarId",
                        column: x => x.MedicinskaSestraTehnicarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicinskiTretman_AspNetUsers_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Novost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AdministratorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novost_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Odluka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pdfFajl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdministratorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odluka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odluka_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministratorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oglas_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posjeta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Odobreno = table.Column<bool>(type: "bit", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicinskaSestraTehnicarId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PacijentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posjeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posjeta_AspNetUsers_MedicinskaSestraTehnicarId",
                        column: x => x.MedicinskaSestraTehnicarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posjeta_AspNetUsers_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pregled",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odobreno = table.Column<bool>(type: "bit", nullable: false),
                    Obavljeno = table.Column<bool>(type: "bit", nullable: false),
                    DatumIVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dijagnoza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terapija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoktorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PacijentId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregled", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregled_AspNetUsers_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pregled_AspNetUsers_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LokacijaID",
                table: "AspNetUsers",
                column: "LokacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecijalizacijaDoktorid",
                table: "AspNetUsers",
                column: "SpecijalizacijaDoktorid");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bolest_PacijentId",
                table: "Bolest",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_JavnaNabavka_AdministratorId",
                table: "JavnaNabavka",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_DoktorId",
                table: "Lijek",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_PacijentId",
                table: "Lijek",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinskiTretman_MedicinskaSestraTehnicarId",
                table: "MedicinskiTretman",
                column: "MedicinskaSestraTehnicarId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinskiTretman_PacijentId",
                table: "MedicinskiTretman",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Novost_AdministratorId",
                table: "Novost",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Odluka_AdministratorId",
                table: "Odluka",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_AdministratorId",
                table: "Oglas",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posjeta_MedicinskaSestraTehnicarId",
                table: "Posjeta",
                column: "MedicinskaSestraTehnicarId");

            migrationBuilder.CreateIndex(
                name: "IX_Posjeta_PacijentId",
                table: "Posjeta",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_DoktorId",
                table: "Pregled",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_PacijentId",
                table: "Pregled",
                column: "PacijentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bolest");

            migrationBuilder.DropTable(
                name: "JavnaNabavka");

            migrationBuilder.DropTable(
                name: "Lijek");

            migrationBuilder.DropTable(
                name: "MedicinskiTretman");

            migrationBuilder.DropTable(
                name: "Novost");

            migrationBuilder.DropTable(
                name: "Odluka");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropTable(
                name: "Posjeta");

            migrationBuilder.DropTable(
                name: "Pregled");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Specijalizacija");
        }
    }
}
