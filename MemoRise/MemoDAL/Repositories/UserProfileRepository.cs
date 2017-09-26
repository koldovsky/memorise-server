using MemoDAL.EF;
using MemoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDAL.Repositories
{
    public class UserProfileRepository: BaseRepository<UserProfile>
    {
        public UserProfileRepository(MemoContext context):base(context)
        {

        }
    }
}
