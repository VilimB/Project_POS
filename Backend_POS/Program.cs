using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Models.DbSet;
using Backend_POS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Backend_POS.Service;
// Dodaj ovo za servis koji æeš kreirati

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(); // Dodaj SignalR usluge

builder.Services.AddControllers();
// Saznajte više o konfiguriranju Swagger/OpenAPI na https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequiredLength = 5;
})
.AddEntityFrameworkStores<DataContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

builder.Services.AddAuthorization();

// Registracija repozitorija i servisa
builder.Services.AddScoped<IProizvodRepository, ProizvodRepository>();
builder.Services.AddScoped<IKupacRepository, KupacRepository>();
builder.Services.AddScoped<IStavkeRacunaRepository, StavkeRacunaRepository>();
builder.Services.AddScoped<IZaglavljeRacunaRepository, ZaglavljeRacunaRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

// **Dodaj ovu liniju za novi RacunService**
builder.Services.AddScoped<RacunService>();  // Registriraj RacunService

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roleNames = { "USER", "ADMIN" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notificationHub");

app.Run();
