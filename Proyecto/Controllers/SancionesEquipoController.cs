
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Sanciones_Equipo;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class SancionesEquipoController : Controller
    {
        private Sanciones_Equipo obtenerModelo(gSanciones_Equipo item)
        {

            Sanciones_Equipo modelo = new Sanciones_Equipo();
            modelo.idSancion_Equipo = item.idSancion_Equipo;
            modelo.descripcion = item.descripcion;
            modelo.multa = item.multa;
            modelo.idCategoria_Sancion = item.idCategoria_Sancion;
            modelo.idEquipo = item.idEquipo;
            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cSanciones_Equipo coleccion = new Domain.Collections.cSanciones_Equipo();

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
            Domain.Collections.cSanciones_Equipo coleccion = new Domain.Collections.cSanciones_Equipo();
            ViewBag.Title = "Seleccionar sancion equipo";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gSanciones_Equipo item = new gSanciones_Equipo();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gSanciones_Equipo(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idSancion_Equipo = id;
            ViewBag.NuevaSancion_Equipo = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gSanciones_Equipo item = new gSanciones_Equipo(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Sanciones_Equipo());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Sanciones_Equipo modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gSanciones_Equipo item = new gSanciones_Equipo();
                item.descripcion = modelo.descripcion;
                item.multa = modelo.multa;
                item.idCategoria_Sancion = modelo.idCategoria_Sancion;
                item.idEquipo = modelo.idEquipo;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Sanciones_Equipo", new { id = item.idSancion_Equipo });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El Sanciones_Equipo no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idSancion_Equipo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gSanciones_Equipo item = new gSanciones_Equipo(idSancion_Equipo);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Sanciones_Equipo modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gSanciones_Equipo item = new gSanciones_Equipo(modelo.idSancion_Equipo);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El Sanciones_Equipo seleccionado no es válido.";
                }
                else
                {
                    item.descripcion = modelo.descripcion;
                    item.multa = modelo.multa;
                    item.idCategoria_Sancion = modelo.idCategoria_Sancion;
                    item.idEquipo = modelo.idEquipo;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Sanciones_Equipo", new { id = item.idSancion_Equipo });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El Sancion_Equipo seleccionado no ha podido ser editado";
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

            gSanciones_Equipo gSancion = new gSanciones_Equipo(id);
            if (!gSancion.exist) return HttpNotFound();

            ViewBag.id = gSancion.idSancion_Equipo;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gSanciones_Equipo gSancion = new gSanciones_Equipo(id);
            if (!gSancion.exist)
            {
                result.messaje = "El Sanciones_Equipo seleccionado no es valido";
            }
            else
            {
                gSancion.Quitar(id);
                result.success = gSancion.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El Sancion_Equipo seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }
    }
}