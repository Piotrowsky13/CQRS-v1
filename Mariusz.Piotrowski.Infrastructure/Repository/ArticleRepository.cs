using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Domain.Entities;
using Mariusz.Piotrowski.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mariusz.Piotrowski.Infrastructure.Repository
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly Context _context;
        public ArticleRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task AddAsync(Article entity)
        {
            await _context.Articles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Article entity)
        {
            _context.Articles.Update(entity);
        }

        public void DeleteById(Article entity)
        {
            _context.Articles.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Articles.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Article>> FindAsync(Expression<Func<Article, bool>> predicate)
        {
            return await _context.Articles.Where(predicate).ToListAsync();
        }
    }
}
