using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.ComentariosLive;
using System.Web.Routing;

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
            modelo.minuto = item.minuto;
            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cComentariosLive coleccion = new Domain.Collections.cComentariosLive();

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
            Domain.Collections.cComentariosLive coleccion = new Domain.Collections.cComentariosLive();
            ViewBag.Title = "Seleccionar ComentarioLive";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gComentariosLive item = new gComentariosLive();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gComentariosLive(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idCometarioLive = id;
            ViewBag.NuevoComentarioLive = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gComentariosLive item = new gComentariosLive(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new ComentariosLive());
        }

        // POST: /License/AjaxCreate

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
                item.minuto = modelo.minuto;
                item.texto = modelo.texto;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "ComentariosLive", new { id = item.idComentario  });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El Comentario no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idComentario)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gComentariosLive item = new gComentariosLive(idComentario);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

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
                    item.minuto = modelo.minuto;
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


        // GET: /License/AjaxDelete

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gComentariosLive gComentario = new gComentariosLive(id);
            if (!gComentario.exist) return HttpNotFound();

            ViewBag.id = gComentario.idComentario;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

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
    }
}