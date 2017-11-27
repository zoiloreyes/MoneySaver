using FinanzasPersonales.Models;
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

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult CrearCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevaCategoria = db.Categorias.Add(categoria);
                    db.SaveChanges();
                    return Json(new { Success = true, Message = "Categoria creada!", Data = nuevaCategoria });
                }
                else
                    return Json(new { Succes = false, Message = "Llene los campos correctamente" });          
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = $"Ocurrio un error: {e.Message}" });
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
