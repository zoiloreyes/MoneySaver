using FinanzasPersonales.Extensions;
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
                var EstadosCuentaBanco = db.EstadoCuentaBanco.ToList().Select(x => new { Text = x.Estado, Value = x.EstadoCuentaBancoID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = EstadosCuentaBanco }, JsonRequestBehavior.AllowGet);
            }catch(Exception e) {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }
                
        }
        [HttpGet]
        public ActionResult GetCuentasBanco()
        {
            try
            {
                var CuentasBanco = db.CuentaBanco.ToList().Where(x => x.UsuarioID == Int32.Parse(User.Identity.GetMoneySaverUserID())).Select(x => new { CuentaBancoID = x.CuentaBancoID, NumeroCuenta = x.NumeroCuenta });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = CuentasBanco }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CrearCuenta(CuentaBanco cuenta)
        {
            cuenta.UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID());
            try
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        Console.Write(error);
                    }
                }
                if (ModelState.IsValid)
                {
                    var nuevaCuenta = db.CuentaBanco.Add(cuenta);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Nueva cuenta creada", Data = nuevaCuenta });
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

        //Detalles/5
        public ActionResult DetalleCuenta(int? id)
        {
            var cuenta = db.CuentaBanco.Find(id);
            if (id != null)          
                return View(cuenta);
            
            return RedirectToAction("Index");
        }
    }
}