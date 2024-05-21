using Backend_POS.Models.DbSet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Backend_POS.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<ZaglavljeRacuna> ZaglavljeRacuna { get; set; }
    public DbSet<Kupac> Kupac { get; set; }
    public DbSet<Proizvod> Proizvod { get; set; }
    public DbSet<StavkeRacuna> StavkeRacuna { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        List<IdentityRole> roles= new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            },
           
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);


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