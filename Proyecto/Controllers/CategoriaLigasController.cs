using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Categoria_Ligas;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class CategoriaLigasController : Controller
    {
        private Categoria_Ligas obtenerModelo(gCategoria_Ligas item)
        {

            Categoria_Ligas modelo = new Categoria_Ligas();
            modelo.idCategoriaLiga = item.idCategoriaLiga;
            modelo.NombreCategoria = item.NombreCategoria;

            return modelo;
        }


        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cCategoria_Ligas coleccion = new Domain.Collections.cCategoria_Ligas();
            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }


        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cCategoria_Ligas coleccion = new Domain.Collections.cCategoria_Ligas();
            ViewBag.Title = "Seleccionar Categoría de la liga";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }


        public ActionResult Gestion(int id)
        {
            gCategoria_Ligas item = new gCategoria_Ligas();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gCategoria_Ligas(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idCategoriaLiga = id;
            ViewBag.NuevaCategoriaLiga = !item.exist;

            return View();
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCategoria_Ligas item = new gCategoria_Ligas(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Categoria_Ligas());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Categoria_Ligas modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gCategoria_Ligas item = new gCategoria_Ligas();
                item.NombreCategoria = modelo.NombreCategoria;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "CategoriaLigas", new { id = item.idCategoriaLiga });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "La categoria ligas no ha podido ser creada.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idArbitro)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCategoria_Ligas item = new gCategoria_Ligas(idArbitro);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Categoria_Ligas modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gCategoria_Ligas item = new gCategoria_Ligas(modelo.idCategoriaLiga);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "La categoria liga seleccionado no es válida.";
                }
                else
                {
                    item.NombreCategoria = modelo.NombreCategoria;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "CategoriaLiga", new { id = item.idCategoriaLiga });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El CategoriaLiga seleccionado no ha podido ser editado";
                    }

                }
            }
            return PartialView("_AjaxEdit", modelo);
        }



        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCategoria_Ligas gCategoria = new gCategoria_Ligas(id);
            if (!gCategoria.exist) return HttpNotFound();

            ViewBag.id = gCategoria.idCategoriaLiga;

            return PartialView("_Delete");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gCategoria_Ligas gCategoria = new gCategoria_Ligas(id);
            if (!gCategoria.exist)
            {
                result.messaje = "El gCategoria seleccionado no es valido";
            }
            else
            {
                gCategoria.Quitar(id);
                result.success = gCategoria.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "La categoria liga seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

    }
}