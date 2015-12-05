using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.CategoriaSanciones;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class CategoriaSancionesController : Controller
    {
        private CategoriaSanciones obtenerModelo(gCategoriasSanciones item)
        {

            CategoriaSanciones modelo = new CategoriaSanciones();
            modelo.idCategoriaSancion = item.idCategoriaSancion;
            modelo.Nombre = item.Nombre;
            modelo.Descripcion = item.Descripcion;

            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cCategoriasSanciones coleccion = new Domain.Collections.cCategoriasSanciones();

            //if (User.IsInRole(Domain.Definitions.eRolesUsers.Administrador.ToString()))
            //{
            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
            //}
            //else
            //{
            //    return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
            //}
        }

        // GET: /License/Selector

        public ActionResult Selector(string searchStr /*,long idCliente*/)
        {
            //ViewBag.idCliente = idCliente;
            Domain.Collections.cCategoriasSanciones coleccion = new Domain.Collections.cCategoriasSanciones();
            ViewBag.Title = "Seleccionar Categoria Sancion";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gCategoriasSanciones item = new gCategoriasSanciones();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gCategoriasSanciones(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idCategoriaSancion = id;
            ViewBag.NuevaCategoriaSancion = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCategoriasSanciones item = new gCategoriasSanciones(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new CategoriaSanciones());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(CategoriaSanciones  modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gCategoriasSanciones item = new gCategoriasSanciones();
                item.Nombre = modelo.Nombre;
                item.Descripcion = modelo.Descripcion;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "CategoriaSancion", new { id = item.idCategoriaSancion });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El CategoriaSancion no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idCategoriaSancion)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCategoriasSanciones item = new gCategoriasSanciones(idCategoriaSancion);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(CategoriaSanciones modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gCategoriasSanciones item = new gCategoriasSanciones(modelo.idCategoriaSancion);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El CategoriaSancion seleccionado no es válido.";
                }
                else
                {
                    item.Nombre = modelo.Nombre;
                    item.Descripcion = modelo.Descripcion;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Arbitros", new { id = item.idCategoriaSancion });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El CategoriaSancion seleccionado no ha podido ser editado";
                    }

                }
            }
            return PartialView("_AjaxEdit", modelo);
        }


        // GET: /License/AjaxDelete

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCategoriasSanciones gCategoria = new gCategoriasSanciones(id);
            if (!gCategoria.exist) return HttpNotFound();

            ViewBag.id = gCategoria.idCategoriaSancion;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gCategoriasSanciones gCategoria = new gCategoriasSanciones(id);
            if (!gCategoria.exist)
            {
                result.messaje = "El gCategoriasSanciones seleccionado no es valido";
            }
            else
            {
                gCategoria.Quitar(id);
                result.success = gCategoria.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El gCategoriasSanciones seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

    }
}