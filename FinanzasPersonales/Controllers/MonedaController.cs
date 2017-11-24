using FinanzasPersonales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    public class MonedaController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult GetMonedas()
        {
            try
            {
                var Monedas = db.Moneda.ToList().Select(x => new { Text = x.Nombre, Value = x.MonedaID, Codigo = x.Codigo });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = Monedas }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}