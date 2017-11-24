using FinanzasPersonales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    public class TipoCategoriaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult GetEstadoCategoria()
        {
            try
            {
                var Tipos = db.TiposCategoria.ToList().Select(x => new { Text = x.Tipo, Value = x.TipoCategoriaID });
                return Json(new { Success = true, Message = "Lista de tipos cargada correctamente", Data = Tipos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}