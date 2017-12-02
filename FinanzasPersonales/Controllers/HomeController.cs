using FinanzasPersonales.Models;
using FinanzasPersonales.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace FinanzasPersonales.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetResumenHTML()
        {
            ViewBag.Mes = DateTime.Now.ToString("MMMM", new CultureInfo("es-ES"));
            var id = Int32.Parse(User.Identity.GetMoneySaverUserID());
            var usuario = db.Users1.Find(Int32.Parse(User.Identity.GetMoneySaverUserID()));
            return PartialView(usuario);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}