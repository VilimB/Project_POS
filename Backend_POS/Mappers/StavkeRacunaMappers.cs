using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.Stavke_Racuna;
using Backend_POS.Models.DTO.StavkeRacuna;

namespace Backend_POS.Mappers
{
    public static class StavkeRacunaMappers
    {
        public static StavkeRacunaDTO ToStavkeRacunaDTO(this StavkeRacuna stavkeRacunaModel)
        {
            return new StavkeRacunaDTO
            {
                Id = stavkeRacunaModel.Id,
                Kolicina = stavkeRacunaModel.Kolicina,
                Cijena = stavkeRacunaModel.Cijena,
                Popust = stavkeRacunaModel.Popust,
                IznosPopusta = stavkeRacunaModel.IznosPopusta,
                Vrijednost = stavkeRacunaModel.Vrijednost,
                ProizvodId = stavkeRacunaModel.ProizvodId,
                ZaglavljeRacunaId = stavkeRacunaModel.ZaglavljeRacunaId,

            };

        }
        public static StavkeRacuna ToStavkeRacunaFromCreateDTO(this CreateStavkeRacunaRequestDTO stavkeRacunaDTO, int zaglavljeRacunaId, int proizvodId)
        {
            return new StavkeRacuna
            {
                Kolicina = stavkeRacunaDTO.Kolicina,
                Cijena = stavkeRacunaDTO.Cijena,
                Popust = stavkeRacunaDTO.Popust,
                IznosPopusta = stavkeRacunaDTO.IznosPopusta,
                Vrijednost = stavkeRacunaDTO.Vrijednost,
                ProizvodId = proizvodId,
                ZaglavljeRacunaId = zaglavljeRacunaId,

            };
        }
    }
}
