using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.ComentariosLive;
using System.Web.Routing;
using Domain.Collections;

namespace Proyecto.Controllers
{
    public class ComentariosLiveController : Controller
    {
        private ComentariosLive obtenerModelo(gComentariosLive item)
        {

            ComentariosLive modelo = new ComentariosLive();
            modelo.idComentario = item.idComentario;
            modelo.idLive = item.idLive;
            modelo.texto = item.texto;
            modelo.horaPublicacion = item.horaPublicacion;
            return modelo;
        }

        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cComentariosLive coleccion = new Domain.Collections.cComentariosLive();
            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }

        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cComentariosLive coleccion = new Domain.Collections.cComentariosLive();
            ViewBag.Title = "Seleccionar ComentarioLive";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }


        public ActionResult Gestion(int id, int idLive)
        {
            gComentariosLive item = new gComentariosLive();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gComentariosLive(id);
                if (!item.exist) return HttpNotFound();
            }
            ViewBag.idLive = idLive;
            ViewBag.idComentarioLive = id;
            ViewBag.NuevoComentarioLive = !item.exist;

            return View();
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gComentariosLive item = new gComentariosLive(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate(int id)
        {
            ViewBag.idLive = id;
            gLive live = new gLive(id);
            ViewBag.marcadorLocal = live.marcadorLocal ?? 0;
            ViewBag.marcadorVisitante = live.marcadorVisitante ?? 0;
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new ComentariosLive());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(ComentariosLive modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gComentariosLive item = new gComentariosLive();
                item.idLive = modelo.idLive;
                item.horaPublicacion = DateTime.Now;
                item.texto = modelo.texto;
                gLive live = new gLive((int)(modelo.idLive));
                    live.marcadorLocal = modelo.marcadorLocal;
                    live.marcadorVisitante = modelo.marcadorVisitatne;
                    live.save();

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("partidoEnDirecto", "Live", new { idLive = item.idLive });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El Comentario no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idComentario)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gComentariosLive item = new gComentariosLive(idComentario);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(ComentariosLive modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gComentariosLive item = new gComentariosLive(modelo.idComentario);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El ComentarioLive seleccionado no es válido.";
                }
                else
                {
                    item.idLive = modelo.idLive;
                    item.horaPublicacion = modelo.horaPublicacion;
                    item.texto = modelo.texto;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "ComentariosLive", new { id = item.idComentario });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El ComentarioLive seleccionado no ha podido ser editado";
                    }

                }
            }
            return PartialView("_AjaxEdit", modelo);
        }



        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gComentariosLive gComentario = new gComentariosLive(id);
            if (!gComentario.exist) return HttpNotFound();

            ViewBag.id = gComentario.idComentario;

            return PartialView("_Delete");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gComentariosLive gComentario = new gComentariosLive(id);
            if (!gComentario.exist)
            {
                result.messaje = "El Comentario seleccionado no es valido";
            }
            else
            {
                gComentario.Quitar(id);
                result.success = gComentario.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El Comentario seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

            public ActionResult borrarComentario(int id)
        {
            gComentariosLive gComentario = new gComentariosLive(id);
            int idLive = (int)gComentario.idLive;
                gComentario.Quitar(id);              
            

            return RedirectToAction("partidoEnDirecto", "Live", new { idLive });
        }
    }
}