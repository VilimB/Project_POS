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
                ZaglavljeId = zaglavljeRacunaModel.ZaglavljeId,
                Broj = zaglavljeRacunaModel.Broj,
                Datum = (DateTime)zaglavljeRacunaModel.Datum,
                Napomena = zaglavljeRacunaModel.Napomena,
                KupacId = zaglavljeRacunaModel.KupacId,
                StavkeRacunas = zaglavljeRacunaModel.StavkeRacunas.Select(c => c.ToStavkeRacunaDTO()).ToList()


            };

        }
        public static ZaglavljeRacuna ToZaglavljeRacunaFromCreateDTO(this CreateZaglavljeRacunaRequestDTO zaglavljeRacunaDTO, int kupacId)
        {
            return new ZaglavljeRacuna
            {
                Broj = zaglavljeRacunaDTO.Broj,
                Datum = zaglavljeRacunaDTO.Datum,
                Napomena = zaglavljeRacunaDTO.Napomena,
                KupacId = zaglavljeRacunaDTO.KupacId,

            };
        }
    }
}