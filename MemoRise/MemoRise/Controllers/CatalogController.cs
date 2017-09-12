using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using MemoDAL.Entities;
using MemoBll;

namespace MemoRise.Controllers
{
    public class CatalogController : ApiController
    {
        public string GetCategories()
        {
            CatalogBll catalog = new CatalogBll();
            var categories = JsonConvert.SerializeObject(catalog.GetAllCategories());
            return categories;
        }
    }
}
