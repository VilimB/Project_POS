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
            .HasForeignKey(e => e.ZaglavljeRacunaId)
            .HasPrincipalKey(e => e.Id);
        
        modelBuilder.Entity<Kupac>()
            .HasMany(e => e.ZaglavljeRacunas)
            .WithOne(e => e.Kupac)
            .HasForeignKey(e => e.KupacId)
            .HasPrincipalKey(e => e.Id);

        modelBuilder.Entity<Proizvod>()
            .HasMany(e => e.StavkeRacunas)
            .WithOne(e => e.Proizvod)
            .HasForeignKey(e => e.ProizvodId)
            .HasPrincipalKey(e => e.Id);
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacija ZaglavljeRacuna -> Kupac
        modelBuilder.Entity<Zaglavlje_racuna>()
            .HasOne(zr => zr.Kupac)
            .WithMany()
            .HasForeignKey(zr => zr.KupacID);

        // Relacija StavkaRacuna -> ZaglavljeRacuna
        modelBuilder.Entity<Stavke_racuna>()
            .HasOne(sr => sr.ZaglavljeRacuna)
            .WithMany(zr => zr.StavkeRacuna)
            .HasForeignKey(sr => sr.Zaglavlje_racunaID);
    
        // Relacija StavkaRacuna -> Proizvod
        modelBuilder.Entity<Stavke_racuna>()
            .HasOne(sr => sr.Proizvod)
            .WithMany()
            .HasForeignKey(sr => sr.ProizvodID);
    }*/
}