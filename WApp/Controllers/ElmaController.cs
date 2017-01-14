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
    }
}