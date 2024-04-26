﻿using Backend_POS.Data;
using Backend_POS.Interfaces;
using Backend_POS.Models.DbSet;
using Backend_POS.Models.DTO.Kupac;
using Backend_POS.Models.DTO.StavkeRacuna;
using Microsoft.EntityFrameworkCore;

namespace Backend_POS.Repository
{
    public class StavkeRacunaRepository : IStavkeRacunaRepository
    {
        private readonly DataContext _context;
        public StavkeRacunaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<StavkeRacuna> CreateAsync(StavkeRacuna stavkeRacunaModel)
        {
            await _context.StavkeRacuna.AddAsync(stavkeRacunaModel);
            await _context.SaveChangesAsync();
            return stavkeRacunaModel;
        }

        public async Task<StavkeRacuna> DeleteAsync(int id)
        {
            {
                var stavkeRacunaModel = await _context.StavkeRacuna.FirstOrDefaultAsync(x => x.Id == id);
                if (stavkeRacunaModel == null)
                {
                    return null;
                }

                _context.StavkeRacuna.Remove(stavkeRacunaModel);
                await _context.SaveChangesAsync();
                return stavkeRacunaModel;
            }
        }

        public async Task<List<StavkeRacuna>> GetAllAsync()
        {
            return await _context.StavkeRacuna.ToListAsync();
        }

        public async Task<StavkeRacuna> GetByIdAsync(int id)
        {
            return await _context.StavkeRacuna.FindAsync(id);
        }

        public async Task<StavkeRacuna> UpdateAsync(int id, UpdateStavkeRacunaRequestDTO stavkeRacunaDTO)
        {
            var existingStavkeRacuna = await _context.StavkeRacuna.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStavkeRacuna == null)
            {
                return null;
            }
            existingStavkeRacuna.Kolicina = stavkeRacunaDTO.Kolicina;
            existingStavkeRacuna.Cijena = stavkeRacunaDTO.Cijena;
            existingStavkeRacuna.Popust = stavkeRacunaDTO.Popust;
            existingStavkeRacuna.IznosPopusta = stavkeRacunaDTO.IznosPopusta;
            existingStavkeRacuna.Vrijednost = stavkeRacunaDTO.Vrijednost;


            await _context.SaveChangesAsync();
            return existingStavkeRacuna;
        }
    }
}
