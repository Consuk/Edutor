using System.Collections.Generic;
using System.Threading.Tasks;
using BookSummary.Domain.Entities;
using BookSummary.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSummary.Infrastructure.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly DbContext _context;

        public ContentRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Content> GetByIdAsync(int id)
        {
            return await _context.Set<Content>().FindAsync(id);
        }

        public async Task<IEnumerable<Content>> GetAllAsync()
        {
            return await _context.Set<Content>().ToListAsync();
        }

        public async Task<Content> AddAsync(Content content)
        {
            _context.Set<Content>().Add(content);
            await _context.SaveChangesAsync();
            return content;
        }

        public async Task UpdateAsync(Content content)
        {
            _context.Entry(content).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Content content)
        {
            _context.Set<Content>().Remove(content);
            await _context.SaveChangesAsync();
        }
    }
}
