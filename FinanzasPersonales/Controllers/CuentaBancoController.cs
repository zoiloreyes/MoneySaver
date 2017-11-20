using FinanzasPersonales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    [Authorize]
    public class CuentaBancoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: CuentaBanco
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCuenta(CuentaBanco cuenta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevaCuenta = db.CuentaBancoes.Add(cuenta);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Cuenta creada correctamente", Data = nuevaCuenta });
                }
                else
                {
                    return Json(new { Success = false, Message = "Los datos no tienen el formato correcto" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }
    }
}