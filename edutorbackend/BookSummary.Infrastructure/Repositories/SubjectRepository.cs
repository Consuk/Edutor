using System.Collections.Generic;
using System.Threading.Tasks;
using BookSummary.Domain.Entities;
using BookSummary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSummary.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DbContext _context;

        public SubjectRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Subject> GetByIdAsync(int id)
        {
            return await _context.Set<Subject>().FindAsync(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Set<Subject>().ToListAsync();
        }

        public async Task<Subject> AddAsync(Subject subject)
        {
            _context.Set<Subject>().Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task UpdateAsync(Subject subject)
        {
            _context.Entry(subject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subject subject)
        {
            _context.Set<Subject>().Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}
