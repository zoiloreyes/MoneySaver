using FinanzasPersonales.Extensions;
using FinanzasPersonales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    public class TransaccionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transaccion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCuenta(TransaccionViewModel transaccionVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    //var nuevaCuenta = db.CuentasBanco.Add(cuenta);
                    //db.SaveChanges();
                    //return Json(new { Success = true, Message = "Nueva cuenta creada", Data = nuevaCuenta });
                    return Json(new { Success = true, Message = "Nueva cuenta creada" });
                }
                else
                {
                    return Json(new { Success = false, Message = "Llene los campos correctamente" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error :(" });
            }
        }

    }
}