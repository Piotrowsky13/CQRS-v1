using Mariusz.Piotrowski.Application.Interfaces.IRepository;
using Mariusz.Piotrowski.Infrastructure.Presistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Infrastructure.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private readonly Context _context;
        public StatsRepository(Context context)
        {
            _context = context;
        }

        public async Task<string?> GetMostUsedCategoryAsync()
        {
            return await _context.Articles
                .Where(a => a.Category != null)
                .GroupBy(a => a.Category!.Name)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetAllPublishedArticles()
        {
            return await _context.Articles
                .Where(a => a.Status == Domain.Enums.Status.Published)
                .CountAsync();
        }

        public async Task<int> GetAllDraftedArticles()
        {
            return await _context.Articles
                .Where(a => a.Status == Domain.Enums.Status.Draft)
                .CountAsync();
        }
    }
}
