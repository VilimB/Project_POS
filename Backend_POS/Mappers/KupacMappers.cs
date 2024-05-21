using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Kupac;
using Backend_POS.Models.DTO.Proizvod;

namespace Backend_POS.Mappers
{
    public static class KupacMappers
    {
        public static KupacDTO ToKupacDTO(this Kupac kupacModel)
        {
            return new KupacDTO
            {
                KupacId = kupacModel.KupacId,
                SifraKupac = kupacModel.SifraKupac,
                NazivKupac = kupacModel.NazivKupac,
                Adresa = kupacModel.Adresa,
                Mjesto = kupacModel.Mjesto,
                ZaglavljeRacunas = kupacModel.ZaglavljeRacunas.Select(c => c.ToZaglavljeRacunaDTO()).ToList()

            };

        }
        public static Kupac ToKupacFromCreateDTO(this CreateKupacRequestDTO kupacDTO)
        {
            return new Kupac
            {
                SifraKupac = kupacDTO.SifraKupac,
                NazivKupac = kupacDTO.NazivKupac,
                Adresa = kupacDTO.Adresa,
                Mjesto = kupacDTO.Mjesto,
        };
        }
    }
}
