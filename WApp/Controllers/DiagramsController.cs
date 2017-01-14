using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WApp.Models;

namespace WApp.Controllers
{
    public class DiagramsController : Controller
    {

        // GET: Diagrams
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TheGood()
        {
            SampleContext context = new SampleContext();
            var model = new DiagramsModels();
            model.process = Data.GetMovie();
            model.Genres = from genre in Data.GetGenres()
                           select new SelectListItem { Text = genre.Name, Value = genre.Id.ToString() };
            return View(model);
        }
    }
}