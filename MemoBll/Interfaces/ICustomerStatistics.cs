using System.Collections.Generic;
using MemoDAL.Entities;

namespace MemoBll.Interfaces
{
    public interface ICustomerStatistics
    {
        IEnumerable<Statistics> GetStatistics(string userId, int cardId);
        void SaveStatistics(Statistics statistics);
    }
}
