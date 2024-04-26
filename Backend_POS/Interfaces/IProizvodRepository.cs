using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;

namespace Backend_POS.Interfaces
{
    public interface IProizvodRepository
    {
        Task<List<Proizvod>> GetAllAsync();
        Task<Proizvod> GetByIdAsync(int id);
        Task<Proizvod> CreateAsync(Proizvod proizvodModel);
        Task<Proizvod> UpdateAsync(int id, UpdateProizvodRequestDTO proizvodRequestDTO);
        Task<Proizvod> DeleteAsync(int id);
    }
}
