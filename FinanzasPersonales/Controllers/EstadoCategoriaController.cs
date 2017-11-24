using FinanzasPersonales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    public class EstadoCategoriaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult GetEstadoCategoria()
        {
            try
            {
                var Estados = db.EstadosCategoria.ToList().Select(x => new { Text = x.Estado, Value = x.EstadoCategoriaID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = Estados }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}