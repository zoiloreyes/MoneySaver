using FinanzasPersonales.Extensions;
using FinanzasPersonales.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasPersonales.Controllers
{
    [Authorize]
    public class BancoController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult GetBancosUsuario()
        {
            try
            {
                var currentUser = UserManager.FindById(User.Identity.GetUserId());
                var MoneySaverUser = currentUser.User;
                var Bancos = db.Banco.ToList().Where(x => x.UsuarioID == MoneySaverUser.Id ).Select(x => new { Text = x.NombreBanco, Value = x.BancoID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = Bancos }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult CrearBanco(Banco banco)
        {
            banco.UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID());
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Success = false, Message = "Llene los campos correctamente" });
                }


                var nuevoBanco = db.Banco.Add(banco);
                db.SaveChanges();
                return Json(new { Success = true, Message = "Nuevo banco creado", Data = banco });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" });
            }

        }
    }
}