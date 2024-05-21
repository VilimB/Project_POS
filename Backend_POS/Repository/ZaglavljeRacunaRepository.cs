using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Kupac;
using Backend_POS.Models.DTO.ZaglavljeRacuna;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Repository
{
    public class ZaglavljeRacunaRepository : IZaglavljeRacunaRepository
    {
        private readonly DataContext _context;
        public ZaglavljeRacunaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ZaglavljeRacuna> CreateAsync(ZaglavljeRacuna zaglavljeRacunaModel)
        {
            await _context.ZaglavljeRacuna.AddAsync(zaglavljeRacunaModel);
            await _context.SaveChangesAsync();
            return zaglavljeRacunaModel;
        }

        public async Task<ZaglavljeRacuna> DeleteAsync(int id)
        {
            {
                var zaglavljeRacunaModel = await _context.ZaglavljeRacuna.FirstOrDefaultAsync(x => x.ZaglavljeId == id);
                if (zaglavljeRacunaModel == null)
                {
                    return null;
                }

                _context.ZaglavljeRacuna.Remove(zaglavljeRacunaModel);
                await _context.SaveChangesAsync();
                return zaglavljeRacunaModel;
            }
        }

        public async Task<List<ZaglavljeRacuna>> GetAllAsync()
        {
            return await _context.ZaglavljeRacuna.Include(c => c.StavkeRacunas).ToListAsync();
        }

        public async Task<ZaglavljeRacuna> GetByIdAsync(int id)
        {
            return await _context.ZaglavljeRacuna.Include(c => c.StavkeRacunas).FirstOrDefaultAsync(i => i.ZaglavljeId == id);
        }

        

        public async Task<ZaglavljeRacuna> UpdateAsync(int id, UpdateZaglavljeRacunaRequestDTO zaglavljeRacunaDTO)
        {
            var existingZaglavljeRacuna = await _context.ZaglavljeRacuna.FirstOrDefaultAsync(x => x.ZaglavljeId == id);
            if (existingZaglavljeRacuna == null)
            {
                return null;
            }
            existingZaglavljeRacuna.Broj = zaglavljeRacunaDTO.Broj;
            existingZaglavljeRacuna.Datum = zaglavljeRacunaDTO.Datum;
            existingZaglavljeRacuna.Napomena = zaglavljeRacunaDTO.Napomena;
            existingZaglavljeRacuna.KupacId = zaglavljeRacunaDTO.KupacId;

            await _context.SaveChangesAsync();
            return existingZaglavljeRacuna;
        }

        public async Task<bool> ZaglavljeRacunaExists(int id)
        {
            return await _context.ZaglavljeRacuna.AnyAsync(s => s.ZaglavljeId == id);
        }
        public async Task<int?> GetIdByNumber(int broj)
        {
            var zaglavljeRacuna = await _context.ZaglavljeRacuna.FirstOrDefaultAsync(zr => zr.Broj == broj);
            return zaglavljeRacuna?.ZaglavljeId;
        }

    }
}

