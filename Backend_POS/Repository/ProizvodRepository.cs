using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Proizvod;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Repository
{
    public class ProizvodRepository : IProizvodRepository
    {
        private readonly DataContext _context;
        public ProizvodRepository(DataContext context) 
        {
            _context= context;
        }

        public async Task<List<Proizvod>> GetAllAsync()
        {
            return await _context.Proizvod.Include(c => c.StavkeRacunas).ToListAsync();
        }

        public async Task<Proizvod> GetByIdAsync(int id)
        {
            return await _context.Proizvod.Include(c => c.StavkeRacunas).FirstOrDefaultAsync(i => i.ProizvodId == id);
        }

        public async Task<Proizvod> UpdateAsync(int id, UpdateProizvodRequestDTO proizvodDTO)
        {
            var existingProizvod = await _context.Proizvod.FirstOrDefaultAsync(x => x.ProizvodId == id);
            if (existingProizvod == null)
            {
                return null;
            }
            existingProizvod.SifraProizvod = proizvodDTO.SifraProizvod;
            existingProizvod.NazivProizvod = proizvodDTO.NazivProizvod;
            existingProizvod.JedinicaMjere = proizvodDTO.JedinicaMjere;
            existingProizvod.CijenaProizvod = proizvodDTO.CijenaProizvod;
            existingProizvod.Stanje = proizvodDTO.Stanje;
            
            await _context.SaveChangesAsync();
            return existingProizvod;
        }
        public async Task<Proizvod> CreateAsync(Proizvod proizvodModel)
        {
            await _context.Proizvod.AddAsync(proizvodModel);
            await _context.SaveChangesAsync();
            return proizvodModel;
        }

        public async Task<Proizvod> DeleteAsync(int id)
        {
            var proizvodModel = await _context.Proizvod.FirstOrDefaultAsync(x => x.ProizvodId == id);
            if (proizvodModel == null)
            {
                return null;
            }

            _context.Proizvod.Remove(proizvodModel);
            await _context.SaveChangesAsync();
            return proizvodModel;
        }
        public async Task<int?> GetIdByName(string nazivProizvod)
        {
            var proizvod = await _context.Proizvod.FirstOrDefaultAsync(p => p.NazivProizvod == nazivProizvod);
            return proizvod?.ProizvodId;
        }

        public async Task<bool> ProizvodExists(int id)
        {
            return await _context.Proizvod.AnyAsync(s => s.ProizvodId == id);
        }
    }
}
