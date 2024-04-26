using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Kupac;
using Backend_POS.Models.DTO.Proizvod;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Repository
{
    public class KupacRepository : IKupacRepository
    {
        private readonly DataContext _context;
        public KupacRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Kupac> CreateAsync(Kupac kupacModel)
        {
            await _context.Kupac.AddAsync(kupacModel);
            await _context.SaveChangesAsync();
            return kupacModel;
        }

        public async Task<Kupac> DeleteAsync(int id)
        {
            {
                var kupacModel = await _context.Kupac.FirstOrDefaultAsync(x => x.Id == id);
                if (kupacModel == null)
                {
                    return null;
                }

                _context.Kupac.Remove(kupacModel);
                await _context.SaveChangesAsync();
                return kupacModel;
            }
        }

        public async Task<List<Kupac>> GetAllAsync()
        {
            return await _context.Kupac.ToListAsync();
        }

        public async Task<Kupac> GetByIdAsync(int id)
        {
            return await _context.Kupac.FindAsync(id);
        }

        public async Task<Kupac> UpdateAsync(int id, UpdateKupacRequestDTO kupacDTO)
        {
            var existingKupac = await _context.Kupac.FirstOrDefaultAsync(x => x.Id == id);
            if (existingKupac == null)
            {
                return null;
            }
            existingKupac.Sifra = kupacDTO.Sifra;
            existingKupac.Naziv = kupacDTO.Naziv;
            existingKupac.Adresa = kupacDTO.Adresa;
            existingKupac.Mjesto = kupacDTO.Mjesto;

            await _context.SaveChangesAsync();
            return existingKupac;
        }
    }
}
