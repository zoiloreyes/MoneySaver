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
        public ActionResult CrearTransaccion(TransaccionViewModel transaccionVM)
        {
            Transaccion transaccion;
            try
            {
                if (ModelState.IsValid)
                {
                    transaccion = new Transaccion {
                        CategoriaID = transaccionVM.CategoriaID,
                        CuentaBancoID = transaccionVM.CuentaBancoIDFuente,
                        CuentaPrestamoID = transaccionVM.CuentaPrestamoIDFuente,
                        TarjetaCreditoID = transaccionVM.TarjetaCreditoIDFuente,
                        ContactoID = transaccionVM.ContactoID,
                        No_Ref_Externo = transaccionVM.No_Ref_Externo,  
                        UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID()),
                        MontoIngreso = transaccionVM.MontoIngreso,
                        MontoEgreso = transaccionVM.MontoEgreso,
                        Fecha = transaccionVM.Fecha
                    };
                    db.Transacciones.Add(transaccion);
                    db.SaveChanges();
                    if (transaccionVM.CuentaBancoIDObjetivo != null || transaccionVM.CuentaPrestamoIDObjetivo != null || transaccionVM.TarjetaCreditoIDObjetivo != null)
                    {
                        Transaccion transaccionObjetivo = new Transaccion
                        {
                            CategoriaID = transaccionVM.CategoriaID,
                            CuentaBancoID = transaccionVM.CuentaBancoIDObjetivo,
                            CuentaPrestamoID = transaccionVM.CuentaPrestamoIDObjetivo,
                            TarjetaCreditoID = transaccionVM.TarjetaCreditoIDObjetivo,
                            ContactoID = transaccionVM.ContactoID,
                            No_Ref_Externo = transaccionVM.No_Ref_Externo,
                            UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID()),
                            MontoIngreso = transaccionVM.MontoEgreso,
                            MontoEgreso = transaccionVM.MontoIngreso,
                            Fecha = transaccionVM.Fecha
                        };
                        db.Transacciones.Add(transaccionObjetivo);
                        db.SaveChanges();
                    }
                    return Json(new { Success = true, Message = "Nueva transaccion creada", Data = transaccion });
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