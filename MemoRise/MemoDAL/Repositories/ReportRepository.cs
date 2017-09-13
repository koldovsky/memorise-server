using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemoDAL.Entities;
using System.Data.Entity;
using MemoDAL.EF;

namespace MemoDAL.Repositories
{
    public class ReportRepository: BaseRepository<Report>
    {
        public ReportRepository(MemoContext context):base(context)
        {

        }
    }
}