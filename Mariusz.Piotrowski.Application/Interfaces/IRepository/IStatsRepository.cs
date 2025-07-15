using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariusz.Piotrowski.Application.Interfaces.IRepository
{
    public interface IStatsRepository
    {
        public Task<string?> GetMostUsedCategoryAsync();
        public Task<int> GetAllPublishedArticles();
        public Task<int> GetAllDraftedArticles();

    }
}
