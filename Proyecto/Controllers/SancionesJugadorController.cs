
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.SancionesJugador;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class SancionesJugadorController : Controller
    {
        private SancionesJugador obtenerModelo(gSancionesJugador item)
        {

            SancionesJugador modelo = new SancionesJugador();
            modelo.idSancionJugador = item.idSancionJugador;
            modelo.idJugador = item.idJugador;
            modelo.Descripcion = item.Descripcion;
            modelo.multa = item.multa;
            modelo.idCategoria_Sancion = item.idCategoria_Sancion;
            modelo.idArbitro = item.idArbitro;
            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cSancionesJugador coleccion = new Domain.Collections.cSancionesJugador();

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
            Domain.Collections.cSancionesJugador coleccion = new Domain.Collections.cSancionesJugador();
            ViewBag.Title = "Seleccionar sancion";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gSancionesJugador item = new gSancionesJugador();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gSancionesJugador(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idSancionJugador = id;
            ViewBag.NuevaSancionJugador = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gSancionesJugador item = new gSancionesJugador(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new SancionesJugador());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(SancionesJugador modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gSancionesJugador item = new gSancionesJugador();
                item.idJugador = modelo.idJugador;
                item.Descripcion = modelo.Descripcion;
                item.multa = modelo.multa;
                item.idCategoria_Sancion = modelo.idCategoria_Sancion;
                item.idArbitro = modelo.idArbitro;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "SancionesJugador", new { id = item.idSancionJugador });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El SancionJugador no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idSancionJugador)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gSancionesJugador item = new gSancionesJugador(idSancionJugador);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(SancionesJugador modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gSancionesJugador item = new gSancionesJugador(modelo.idSancionJugador);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El SancionJugador seleccionado no es válido.";
                }
                else
                {
                    item.idJugador = modelo.idJugador;
                    item.Descripcion = modelo.Descripcion;
                    item.multa = modelo.multa;
                    item.idCategoria_Sancion = modelo.idCategoria_Sancion;
                    item.idArbitro = modelo.idArbitro;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "SancionesJugador", new { id = item.idSancionJugador });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El SancionJugador seleccionado no ha podido ser editado";
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

            gSancionesJugador gSancion = new gSancionesJugador(id);
            if (!gSancion.exist) return HttpNotFound();

            ViewBag.id = gSancion.idSancionJugador;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gSancionesJugador gSancion = new gSancionesJugador(id);
            if (!gSancion.exist)
            {
                result.messaje = "El SancionJugador seleccionado no es valido";
            }
            else
            {
                gSancion.Quitar(id);
                result.success = gSancion.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El SancionJugador seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }
    }
}