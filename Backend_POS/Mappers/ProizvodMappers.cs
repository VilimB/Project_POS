using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;


namespace Backend_POS.Mappers
{
    public static class ProizvodMappers
    {
        public static ProizvodDTO ToProizvodDTO(this Proizvod proizvodModel)
        {
            return new ProizvodDTO
            {
                Id = proizvodModel.Id,
                Sifra = proizvodModel.Sifra,
                Naziv = proizvodModel.Naziv,
                JedinicaMjere = proizvodModel.JedinicaMjere,
                Cijena = proizvodModel.Cijena,
                Stanje = proizvodModel.Stanje,

            };

        }

        public static Proizvod ToProizvodFromCreateDTO(this CreateProizvodRequestDTO proizvodDTO)
        {
            return new Proizvod
            {
                Sifra = proizvodDTO.Sifra,
                Naziv = proizvodDTO.Naziv,
                JedinicaMjere = proizvodDTO.JedinicaMjere,
                Cijena = proizvodDTO.Cijena,
                Stanje = proizvodDTO.Stanje,
            };
        }
    }
}
