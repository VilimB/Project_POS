using Backend_POS.Models.DbSet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<ZaglavljeRacuna> ZaglavljeRacuna { get; set; }
    public DbSet<Kupac> Kupac { get; set; }
    public DbSet<Proizvod> Proizvod { get; set; }
    public DbSet<StavkeRacuna> StavkeRacuna { get; set; }
    public DbSet<Racun> Racun { get; set; }  // Dodano za Racun

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Definicija uloga
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "User", NormalizedName = "USER" }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);

        // Odnosi između entiteta
        modelBuilder.Entity<ZaglavljeRacuna>()
            .HasMany(e => e.StavkeRacunas)
            .WithOne(e => e.ZaglavljeRacuna)
            .HasForeignKey(e => e.ZaglavljeId)
            .HasPrincipalKey(e => e.ZaglavljeId);

        modelBuilder.Entity<Kupac>()
            .HasMany(e => e.ZaglavljeRacunas)
            .WithOne(e => e.Kupac)
            .HasForeignKey(e => e.KupacId)
            .HasPrincipalKey(e => e.KupacId);

        modelBuilder.Entity<Proizvod>()
            .HasMany(e => e.StavkeRacunas)
            .WithOne(e => e.Proizvod)
            .HasForeignKey(e => e.ProizvodId)
            .HasPrincipalKey(e => e.ProizvodId);

        // Dodaj odnos između Racun i ZaglavljeRacuna
        modelBuilder.Entity<Racun>()
            .HasOne(e => e.ZaglavljeRacuna)  // Pretpostavka da Racun ima 1:1 odnos s ZaglavljeRacuna
            .WithOne()
            .HasForeignKey<Racun>(e => e.ZaglavljeId);  // Definiraj strani ključ

        // Indeksi za unikatnost
        modelBuilder.Entity<ZaglavljeRacuna>()
            .HasIndex(e => e.Broj)
            .IsUnique();

        modelBuilder.Entity<Kupac>()
            .HasIndex(e => e.SifraKupac)
            .IsUnique();

        modelBuilder.Entity<Proizvod>()
            .HasIndex(e => e.SifraProizvod)
            .IsUnique();
    }
}
