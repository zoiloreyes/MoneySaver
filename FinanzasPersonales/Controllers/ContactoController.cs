using FinanzasPersonales.Models;
using FinanzasPersonales.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    public class ContactoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult GetContactos()
        {
            try
            {
                var Contactos = db.Contactos.ToList().Where(x => x.UsuarioID == Int32.Parse(User.Identity.GetMoneySaverUserID())).Select(x => new { Nombre = x.Nombre, Email = x.Email, Telefono = x.Telefono, Direccion = x.Direccion, Id = x.ContactoID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = Contactos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CrearContacto(Contacto contacto)
        {
            contacto.UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID());
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevoContacto = db.Contactos.Add(contacto);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Nueva cuenta creada", Data = nuevoContacto });
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