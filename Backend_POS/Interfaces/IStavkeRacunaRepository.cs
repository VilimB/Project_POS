using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Backend_POS.Models.DTO.StavkeRacuna;

namespace Backend_POS.Interfaces
{
    public interface IStavkeRacunaRepository
    {
        Task<List<StavkeRacuna>> GetAllAsync();
        Task<StavkeRacuna> GetByIdAsync(int id);
        Task<StavkeRacuna> CreateAsync(StavkeRacuna stavkeRacunaModel);
        Task<StavkeRacuna> UpdateAsync(int id, UpdateStavkeRacunaRequestDTO stavkeRacunaRequestDTO);
        Task<StavkeRacuna> DeleteAsync(int id);
    }
}
