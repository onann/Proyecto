
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Clubes;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class ClubesController : Controller
    {
        private Clubes obtenerModelo(gClubes item)
        {
            
            Clubes modelo = new Clubes();
            modelo.idClub = item.idClub;
            modelo.Nombre = item.Nombre;
            modelo.Localidad = item.Localidad;
            modelo.Telefono = item.Telefono;
            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cClubes coleccion = new Domain.Collections.cClubes();

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
            Domain.Collections.cClubes coleccion = new Domain.Collections.cClubes();
            ViewBag.Title = "Seleccionar Club";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gClubes item = new gClubes();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gClubes(id);
                if (!item.exist) return HttpNotFound();
            }
            
            ViewBag.idClub = id;
            ViewBag.NuevoClub = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gClubes item = new gClubes(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Clubes());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Clubes modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gClubes item = new gClubes();
                item.Nombre = modelo.Nombre;
                item.Localidad = modelo.Localidad;
                item.Telefono = modelo.Telefono;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Clubes", new { id = item.idClub });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El club no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idClub)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gClubes item = new gClubes(idClub);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Clubes modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gClubes item = new gClubes(modelo.idClub);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El club seleccionado no es válido.";
                }
                else
                {
                    item.Nombre = modelo.Nombre;
                    item.Localidad = modelo.Localidad;
                    item.Telefono = modelo.Telefono;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Clubes", new { id = item.idClub });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El club seleccionado no ha podido ser editado";
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

            gClubes gClub = new gClubes(id);
            if (!gClub.exist) return HttpNotFound();

            ViewBag.id = gClub.idClub;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gClubes gClub = new gClubes(id);
            if (!gClub.exist)
            {
                result.messaje = "El club seleccionado no es valido";
            }
            else
            {
                gClub.Quitar(id);
                result.success = gClub.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El club seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

    }
}