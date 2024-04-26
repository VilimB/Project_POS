using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.ZaglavljeRacuna;

namespace Backend_POS.Interfaces
{
    public interface IZaglavljeRacunaRepository
    {
        Task<List<ZaglavljeRacuna>> GetAllAsync();
        Task<ZaglavljeRacuna> GetByIdAsync(int id);
        Task<ZaglavljeRacuna> CreateAsync(ZaglavljeRacuna zaglavljeRacunaModel);
        Task<ZaglavljeRacuna> UpdateAsync(int id, UpdateZaglavljeRacunaRequestDTO zaglavljeRacunaRequestDTO);
        Task<ZaglavljeRacuna> DeleteAsync(int id);
    }
}
