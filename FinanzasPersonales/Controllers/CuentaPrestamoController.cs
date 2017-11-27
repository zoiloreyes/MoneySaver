using FinanzasPersonales.Extensions;
using FinanzasPersonales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinanzasPersonales.Controllers
{
    public class CuentaPrestamoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult GetCuentasPrestamo()
        {
            try
            {
                var CuentasPrestamo = db.CuentasPrestamo.ToList().Where(x => x.UsuarioID == Int32.Parse(User.Identity.GetMoneySaverUserID())).Select(x => new { CuentaPrestamoID = x.CuentaPrestamoID, NombrePrestamo = x.NombrePrestamo });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = CuentasPrestamo }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CrearPrestamo(CuentaPrestamo prestamo)
        {
            prestamo.UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID());
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevoPrestamo = db.CuentasPrestamo.Add(prestamo);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Nueva cuenta creada", Data = nuevoPrestamo });
                }
                else
                {
                    return Json(new { Success = false, Message = "Llene los campos correctamente" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" });
            }
        }
    }
}