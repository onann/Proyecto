using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Live;
using System.Web.Routing;
using Domain.Collections;

namespace Proyecto.Controllers
{
    public class LiveController : Controller
    {
        private Live obtenerModelo(gLive item)
        {

            Live modelo = new Live();
            modelo.idLive = item.idLive;
            modelo.TiempoTranscurrido = item.TiempoTranscurrido;
            modelo.idLocal = item.idLocal;
            modelo.idVisitante = item.idVisitante;
            modelo.marcadorLocal = item.marcadorLocal;
            modelo.marcadorVisitante = item.marcadorVisitante;
            modelo.Date = item.Date;
            modelo.idCampo = item.idCampo;
            modelo.idArbitro = item.idArbitro;
            
            return modelo;
        }
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cLive coleccion = new Domain.Collections.cLive();
            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }

        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cLive coleccion = new Domain.Collections.cLive();
            ViewBag.Title = "Seleccionar Live";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        public ActionResult Gestion(int id, int idPartido)
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
            ViewBag.idPartido = idPartido;

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gLive item = new gLive(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        public ActionResult crearAsignarLive(int id)
        {
            gLive live = new gLive();
            gPartidos partido = new gPartidos(id);
            live.idArbitro = partido.idArbitro;
            live.idCampo = partido.idCampo;
            live.idLocal = partido.idEquipoLocal;
            live.idVisitante = partido.idEquipoVisitante;
            live.save();
            

            partido.idLive = live.idLive;
            partido.save();

            return RedirectToAction("partidosLive", "Partidos");
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idLive)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gLive item = new gLive(idLive);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

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


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gLive gLive = new gLive(id);
            if (!gLive.exist) return HttpNotFound();

            ViewBag.id = gLive.idLive;

            return PartialView("_Delete");
        }

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

        public ActionResult selectorPartidos()
        {
            return View(new cPartidos().listaSinJugar());
        }

        public ActionResult borrarLive(int id, int idPartido)
        {
            gLive live = new gLive(id);
            live.Quitar(id);
            gPartidos partido = new gPartidos(idPartido);
            partido.idLive = null;
            partido.save();

            return RedirectToAction("partidosLive", "Partidos");           


        }

        public ActionResult partidoEnDirecto(int idLive)
        {
            gLive directo = new gLive(idLive);

            gPartidos partido = new gPartidos(directo.getIdPartido());
            Live modelo = new Live();
            gEquipos equipoLocal = new gEquipos(partido.idEquipoLocal);
            gEquipos equipoVisitante = new gEquipos(partido.idEquipoVisitante);


            modelo.idLive = directo.idLive;
            modelo.nombreLocal = equipoLocal.Nombre;
            modelo.nombreVisitante = equipoVisitante.Nombre;
            modelo.marcadorLocal = directo.marcadorLocal;
            modelo.marcadorVisitante = directo.marcadorVisitante;
            modelo.TiempoTranscurrido = directo.TiempoTranscurrido;
            ViewBag.idPartido = directo.getIdPartido();
            ViewBag.idLive = idLive;


            return View("partidoEnDirecto", modelo);
        }

        public ActionResult partidoEnDirecto2(int idLive)
        {
            gLive directo = new gLive(idLive);

            gPartidos partido = new gPartidos(directo.getIdPartido());
            Live modelo = new Live();
            gEquipos equipoLocal = new gEquipos(partido.idEquipoLocal);
            gEquipos equipoVisitante = new gEquipos(partido.idEquipoVisitante);


            modelo.idLive = directo.idLive;
            modelo.nombreLocal = equipoLocal.Nombre;
            modelo.nombreVisitante = equipoVisitante.Nombre;
            modelo.marcadorLocal = directo.marcadorLocal;
            modelo.marcadorVisitante = directo.marcadorVisitante;
            modelo.TiempoTranscurrido = directo.TiempoTranscurrido;
            ViewBag.idPartido = directo.getIdPartido();
            ViewBag.idLive = idLive;


            return PartialView("partidoEnDirecto", modelo);
        }

        public ActionResult Comentarios(int idLive)
        {
            ViewBag.idLive = idLive;
            return PartialView(new cComentariosLive().listaComentariosLive(idLive));
        }

        public ActionResult finalizarLive(int idLive)
        {
            gLive live = new gLive(idLive);
            live.getIdPartido();

            return RedirectToAction("Gestion", "EstadisticasPartidos", new { id = -1, idPartido = live.getIdPartido() }) ;

        }
    }
}