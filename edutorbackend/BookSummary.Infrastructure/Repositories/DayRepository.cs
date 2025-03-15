using System.Collections.Generic;
using System.Threading.Tasks;
using BookSummary.Domain.Entities;
using BookSummary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSummary.Infrastructure.Repositories
{
    public class DayRepository : IDayRepository
    {
        private readonly DbContext _context;

        public DayRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Day> GetByIdAsync(int id)
        {
            return await _context.Set<Day>().FindAsync(id);
        }

        public async Task<IEnumerable<Day>> GetAllAsync()
        {
            return await _context.Set<Day>().ToListAsync();
        }

        public async Task<Day> AddAsync(Day day)
        {
            _context.Set<Day>().Add(day);
            await _context.SaveChangesAsync();
            return day;
        }

        public async Task UpdateAsync(Day day)
        {
            _context.Entry(day).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Day day)
        {
            _context.Set<Day>().Remove(day);
            await _context.SaveChangesAsync();
        }
    }
}
