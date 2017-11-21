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
        [HttpGet]
        public ActionResult GetEstadosCuentaBanco()
        {
            try
            {
                var EstadosCuentaBanco = db.EstadoCuentaBancoes.ToList().Select(x => new { Text = x.Estado, Value = x.EstadoCuentaBancoID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = EstadosCuentaBanco }, JsonRequestBehavior.AllowGet);
            }catch(Exception e) {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }
                
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

        //Detalles/5
        public ActionResult DetalleCuenta(int? id)
        {
            var cuenta = db.CuentaBancoes.Find(id);
            if (id != null)          
                return View(cuenta);
            
            return RedirectToAction("Index");
        }
    }
}