using Backend_POS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Zaglavlje_racuna> Zaglavlje_racuna { get; set; }
    public DbSet<Kupac> Kupac { get; set; }
    public DbSet<Proizvod> Proizvod { get; set; }
    public DbSet<Stavke_racuna> Stavke_racuna { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relacija ZaglavljeRacuna -> Kupac
        modelBuilder.Entity<Zaglavlje_racuna>()
            .HasOne(zr => zr.Kupac)
            .WithMany()
            .HasForeignKey(zr => zr.KupacID);

        // Relacija StavkaRacuna -> ZaglavljeRacuna
        modelBuilder.Entity<Stavke_racuna>()
            .HasOne(sr => sr.Zaglavlje_racuna)
            .WithMany(zr => zr.Stavke_racuna)
            .HasForeignKey(sr => sr.Zaglavlje_racunaID);

        // Relacija StavkaRacuna -> Proizvod
        modelBuilder.Entity<Stavke_racuna>()
            .HasOne(sr => sr.Proizvod)
            .WithMany()
            .HasForeignKey(sr => sr.ProizvodID);
    }
}