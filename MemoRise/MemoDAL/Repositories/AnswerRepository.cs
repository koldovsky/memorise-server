using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MemoDAL.Entities;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public AnswerRepository(MemoContext context):base(context)
        {
            
        }
    }
}