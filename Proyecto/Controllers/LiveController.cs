using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Live;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class LiveController : Controller
    {
        private Live obtenerModelo(gLive item)
        {

            Live modelo = new Live();
            modelo.idLive = item.idLive;
            modelo.TiempoTranscurrido = item.TiempoTranscurrido;
            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cLive coleccion = new Domain.Collections.cLive();

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
            Domain.Collections.cLive coleccion = new Domain.Collections.cLive();
            ViewBag.Title = "Seleccionar Live";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gLive item = new gLive();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gLive(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idLive = id;
            ViewBag.NuevoLive = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gLive item = new gLive(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Live());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Live modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gLive item = new gLive();
                item.TiempoTranscurrido = modelo.TiempoTranscurrido;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Live", new { id = item.idLive });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El live no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idLive)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gLive item = new gLive(idLive);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Live modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gLive item = new gLive(modelo.idLive);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El live seleccionado no es válido.";
                }
                else
                {
                    item.TiempoTranscurrido = modelo.TiempoTranscurrido;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Live", new { id = item.idLive });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El live seleccionado no ha podido ser editado";
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

            gLive gLive = new gLive(id);
            if (!gLive.exist) return HttpNotFound();

            ViewBag.id = gLive.idLive;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gLive gLive = new gLive(id);
            if (!gLive.exist)
            {
                result.messaje = "El live seleccionado no es valido";
            }
            else
            {
                gLive.Quitar(id);
                result.success = gLive.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El live seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }
        public ActionResult prueba()
        {
            regurn null;
        }
    }
}