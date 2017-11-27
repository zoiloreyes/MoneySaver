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
    public class TarjetaCreditoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: TarjetaCredito
        [HttpGet]
        public ActionResult GetEstadosTarjetaCredito()
        {
            try
            {
                var EstadosTarjetaCredito = db.EstadosTarjetaCredito.ToList().Select(x => new { Text = x.Estado, Value = x.EstadoTarjetaCreditoID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = EstadosTarjetaCredito }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult GetTarjetasCredito()
        {
            try
            {
                var TarjetasCredito = db.TarjetasCredito.ToList().Where(x => x.UsuarioID == Int32.Parse(User.Identity.GetMoneySaverUserID())).Select(x => new { TarjetaCreditoID = x.TarjetaCreditoID, NombreTarjeta = x.NombreTarjetaCredito });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = TarjetasCredito }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CrearTarjetaCredito(TarjetaCredito tarjeta)
        {
            tarjeta.UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID());
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevaTarjeta = db.TarjetasCredito.Add(tarjeta);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Nueva cuenta creada", Data = nuevaTarjeta });
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