using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WApp.Models;
using static CodeFirst.Model;

namespace WApp.Controllers
{
    public class DiagramsController : Controller
    {

        // GET: Diagrams
        public ActionResult Index()
        {
            return View("Account/Diagrams");
        }

        public ActionResult TheGood()
        {
            SampleContext context = new SampleContext();
            var model = new DiagramsModels();

            foreach (ProcessHeader header in context.ProcessHeader)
            {
                model.process.Add(header);
            }
            return View(model);
        }
    }
}