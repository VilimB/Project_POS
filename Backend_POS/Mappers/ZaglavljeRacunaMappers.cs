using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.ZaglavljeRacuna;

namespace Backend_POS.Mappers
{
    public static class ZaglavljeRacunaMappers
    {
        public static ZaglavljeRacunaDTO ToZaglavljeRacunaDTO(this ZaglavljeRacuna zaglavljeRacunaModel)
        {
            return new ZaglavljeRacunaDTO
            {
                Id = zaglavljeRacunaModel.Id,
                Broj = zaglavljeRacunaModel.Broj,
                Datum = zaglavljeRacunaModel.Datum,
                Napomena = zaglavljeRacunaModel.Napomena,
                

            };

        }
        public static ZaglavljeRacuna ToZaglavljeRacunaFromCreateDTO(this CreateZaglavljeRacunaRequestDTO zaglavljeRacunaDTO)
        {
            return new ZaglavljeRacuna
            {
                Broj = zaglavljeRacunaDTO.Broj,
                Datum = zaglavljeRacunaDTO.Datum,
                Napomena = zaglavljeRacunaDTO.Napomena,
                
            };
        }
    }
}
