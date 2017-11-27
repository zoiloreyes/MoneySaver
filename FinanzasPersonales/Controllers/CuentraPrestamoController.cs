using FinanzasPersonales.Models;
using FinanzasPersonales.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    [Authorize]
    public class CuentraPrestamoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: CuentraPrestamo
        public ActionResult Index()
        {
            return View();
        }
    }
}