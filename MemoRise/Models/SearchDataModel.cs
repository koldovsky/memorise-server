using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoRise.Models
{
    public class SearchDataModel
    {
        //int page, int pageSize, bool sort, string searchString
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool Sort { get; set; }
        public string SearchString { get; set; }
    }
}