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
                Id = kupacModel.Id,
                Sifra = kupacModel.Sifra,
                Naziv = kupacModel.Naziv,
                Adresa = kupacModel.Adresa,
                Mjesto = kupacModel.Mjesto,

            };

        }
        public static Kupac ToKupacFromCreateDTO(this CreateKupacRequestDTO kupacDTO)
        {
            return new Kupac
            {
                Sifra = kupacDTO.Sifra,
                Naziv = kupacDTO.Naziv,
                Adresa = kupacDTO.Adresa,
                Mjesto = kupacDTO.Mjesto,
        };
        }
    }
}
