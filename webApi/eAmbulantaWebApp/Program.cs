using eAmbulantaWebApp.Data;
using eAmbulantaWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////nacin povezivanja sa bazom
////Inject DbContext
//var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextConnectionString"));

////Inject DbContext
////ko sa videa
//builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContextConnectionString")));

//Inject DbContext
//ko sa videa
builder.Services.AddDbContext<AuthenticationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationContextConnectionString")));

//builder.Services.AddIdentity<Administrator, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();
//builder.Services.AddIdentity<Doktor, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();
//builder.Services.AddIdentity<Pacijent, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();
//builder.Services.AddIdentity<MedicinskaSestraTehnicar, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
});

builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));


var key = Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"].ToString());
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

//omogucavanje pristupa api-u svima
builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

////dodavnje u bazu-------------------------------------------------------------------------------------------
//using (var db = new AppDbContext(optionsBuilder.Options))
//{
//    ////dodan admin
//    //var Adm1 = new Administrator { Ime = "Arman", Prezime = "Rados", Email = "arman.rados@edu.fit.ba", korisnickoIme = "arman", lozinka = "arman12345", Telefon = "0601234567" };
//    //db.Administrator.Add(Adm1);
//    //db.SaveChanges();

//    ////nije dodan pacijent
//    //var Pac = new Pacijent { Ime = "Adin", Prezime = "Ross", korisnickoIme = "adinLive", lozinka = "iShowSpeed1", Email = "youtubenotif@gmail.com", Telefon = "0601717171", JMBG = "1717171717171", datumRodjenja = new DateTime(2000,10,11), LokacijaID = 2};
//    //db.Pacijent.Add(Pac);
//    //db.SaveChanges();

//    ////dodan doktor
//    //var dok = new Doktor { Ime = "Gregory", Prezime = "House", korisnickoIme = "houseMD", lozinka = "cuddy", Email = "houseLupus@gmail.com", Titula = "Dr." };
//    //db.Doktor.Add(dok);
//    //db.SaveChanges();

//    ////dodan med teh
//    //var msh = new MedicinskaSestraTehnicar { Ime = "Felix", Prezime = "Lengyel", Email = "juicerwarlord@gmail.com", korisnickoIme = "xQcL", lozinka = "omegalul777", Obrazovanje = "Srednja strucna sprema", Telefon = "0607777777" };
//    //db.MedicinskaSestraTehnicar.Add(msh);
//    //db.SaveChanges();

//    ////dodana javna nabavka
//    //string pdfFilePath = "C:\\Users\\iamas\\Desktop\\Random\\Zakon o nabavljanju dranju i noenju oruja i municije-slzdk 19-09 4-11 9-13 1-14 13-18.pdf";
//    //byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
//    //var odluka1 = new Odluka { Opis = "Odluka 12/22 Copy b", pdfFajl = bytes, AdministratorID = 1 };
//    //db.Administrator.ToList().Find(adm => 1 == adm.id)?.Odluke.Add(odluka1);
//    //db.SaveChanges();
//}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//omogucavanje pristupa api-u svima - ukljucivanje
app.UseCors("default");

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
