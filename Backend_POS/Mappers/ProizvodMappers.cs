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
                ProizvodId = proizvodModel.ProizvodId,
                SifraProizvod = proizvodModel.SifraProizvod,
                NazivProizvod = proizvodModel.NazivProizvod,
                JedinicaMjere = proizvodModel.JedinicaMjere,
                CijenaProizvod = proizvodModel.CijenaProizvod,
                Stanje = proizvodModel.Stanje,
                StavkeRacunas = proizvodModel.StavkeRacunas.Select(c =>c.ToStavkeRacunaDTO()).ToList()

            };

        }

        public static Proizvod ToProizvodFromCreateDTO(this CreateProizvodRequestDTO proizvodDTO)
        {
            return new Proizvod
            {
                SifraProizvod = proizvodDTO.SifraProizvod,
                NazivProizvod = proizvodDTO.NazivProizvod,
                JedinicaMjere = proizvodDTO.JedinicaMjere,
                CijenaProizvod = proizvodDTO.CijenaProizvod,
                Stanje = proizvodDTO.Stanje,
            };
        }
    }
}
