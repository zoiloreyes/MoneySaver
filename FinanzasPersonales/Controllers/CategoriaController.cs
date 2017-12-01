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
    public class CategoriaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Categoria
        public ActionResult Index()
        {
            var model = db.Categorias.ToList();
            return View(model);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetCategoriaUsuario()
        {
            try
            {
                var Categorias = db.Categorias.ToList().Where(x => x.UsuarioID == Int32.Parse(User.Identity.GetMoneySaverUserID())).Select(x => new { Text = x.Nombre, Value = x.CategoriaID });
                return Json(new { Success = true, Message = "Lista de categorias cargada correctamente", Data = Categorias }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult GetEstadosCategoria()
        {
            try
            {
                var EstadosCategorias = db.EstadosCategoria.ToList().Select(x => new { Text = x.Estado, Value = x.EstadoCategoriaID });
                return Json(new { Success = true, Message = "Lista de estados cargada correctamente", Data = EstadosCategorias }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult GetTiposCategoria()
        {
            try
            {
                var TiposCategorias = db.TiposCategoria.ToList().Select(x => new { Text = x.Tipo, Value = x.TipoCategoriaID });
                return Json(new { Success = true, Message = "Lista de Tipos cargada correctamente", Data = TiposCategorias }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult GetCategoriaHTML()
        {
            var Categorias = db.Categorias.ToList().Where(x => x.UsuarioID == Int32.Parse(User.Identity.GetMoneySaverUserID())).ToList();

            return PartialView(Categorias);

        }
        // POST: Categoria/Create
        [HttpPost]
        public ActionResult CrearCategoria(Categoria categoria)
        {
            categoria.UsuarioID = Int32.Parse(User.Identity.GetMoneySaverUserID());
            try
            {
                if (ModelState.IsValid)
                {
                    Categoria nuevaCategoria = db.Categorias.Add(categoria);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Categoria creada!", Data = nuevaCategoria });
                }
                else
                    return Json(new { Succes = false, Message = "Llene los campos correctamente" });          
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Ocurrio un error :(", Detalle = $"{e.Message} n/ {e.InnerException}" });
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
