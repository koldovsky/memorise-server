using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MemoDAL.Entities;
using MemoDAL.EF;


namespace MemoDAL.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository(MemoContext context):base(context)
        {

        }
    }
}