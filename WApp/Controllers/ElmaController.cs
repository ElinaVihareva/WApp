using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WApp.Managers;

namespace WApp.Controllers
{
    public class ElmaController : Controller
    {
        // GET: Elma
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SyncElma()
        {
            var manager = new ElmaConnectManager(1);
            manager.Sync();
            return new JsonResult { Data = "Ok" } ;
        }
        // GET: Elma
        public ActionResult Process(int header)
        {
            SampleContext context = new SampleContext();

            var groupByReference = (
                                    from m in context.WorkflowInstance
                                    where m.header==header
                                    group m by new { m.process } into g
                                    select new
                                    {
                                        name = g.Key,
                                        x = g.Count(),
                                        y = g.Sum(w=>((((DateTime)w.endDate).Ticks- ((DateTime)w.endDate).Ticks))/ TimeSpan.TicksPerSecond)
                                        
                                    }).ToList(); ;



            return new JsonResult { Data=groupByReference};
        }
        public ActionResult Swimline()
        {
            return View();
        }
        public ActionResult Task()
        {
            return View();
        }
    }
}