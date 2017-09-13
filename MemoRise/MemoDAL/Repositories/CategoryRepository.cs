using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(MemoContext context):base(context)
        {

        }
    }
}