﻿namespace Backend_POS.Models.DbSet
{
    public class Kupac
    {
        public long Id { get; set; } 
        public int Sifra { get; set; } 
        public string Naziv { get; set; } = string.Empty;
        public string Adresa { get; set; } = string.Empty;
        public string Mjesto { get; set; } = string.Empty;
        public ICollection<ZaglavljeRacuna> ZaglavljeRacunas { get; set; }

        // Ova kolekcija omogućuje jednostruku relaciju (1:N) s tablicom ZaglavljeRacuna
        /* public required ICollection<Zaglavlje_racuna> ZaglavljeRacuna { get; set; }*/
    }

}