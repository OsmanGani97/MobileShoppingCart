﻿using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace DMobileSite.Repository
{

    public interface IBrandRepository
    {
        Task AddBrand(Brand brand);
        Task UpdateBrand(Brand brand);
        Task<Brand?> GetBrandById(int id);
        Task DeleteBrand(Brand brand);
        Task<IEnumerable<Brand>> GetBrands();
    }

    public class BrandRepository: IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }

        public async Task<Brand?> GetBrandById(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }


    }
}
