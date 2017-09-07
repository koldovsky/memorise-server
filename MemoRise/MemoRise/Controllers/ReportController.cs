using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoRise.BLL;

namespace MemoRise.Controllers
{
    public class ReportController : ApiController
    {
        private ReportBll reportbll = new ReportBll();

        public IEnumerable<Report> GetAllReports()
        {
            return reportbll.GetAllReports();
        }

        public IEnumerable<Report> GetReports(ReportType reportType)
        {
            return reportbll.GetReports(reportType);
        }

        public Report GetReport(int id)
        {
            return reportbll.GetReport(id);
        }

        public void PostReport(Report item)
        {
            reportbll.AddReport(item);
        }

        public bool PutReport(Report item)
        {
            return reportbll.UpdateReport(item);
        }

        public void DeleteReport(int id)
        {
            reportbll.RemoveReport(id);
        }
    }
}
