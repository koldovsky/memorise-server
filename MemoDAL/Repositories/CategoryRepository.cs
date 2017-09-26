using MemoDAL.Entities;
using MemoDAL.EF;
using MemoDAL.Repositories.Interfaces;

namespace MemoDAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MemoContext context) : base(context) { }
    }
}