using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Kupac;
using Backend_POS.Models.DTO.Proizvod;

namespace Backend_POS.Interfaces
{
    public interface IKupacRepository
    {
        Task<List<Kupac>> GetAllAsync();
        Task<Kupac> GetByIdAsync(int id);
        Task<Kupac> CreateAsync(Kupac kupacModel);
        Task<Kupac> UpdateAsync(int id, UpdateKupacRequestDTO KupacRequestDTO);
        Task<Kupac> DeleteAsync(int id);
        Task<bool> KupacExists(int id);
    }
}
