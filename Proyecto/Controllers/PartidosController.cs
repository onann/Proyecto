using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Partidos;
using System.Web.Routing;
using Domain.Collections;
//using Repositorio;

namespace Proyecto.Controllers
{
    public class PartidosController : Controller
    {
        private Partidos obtenerModelo(gPartidos item)
        {

            Partidos modelo = new Partidos();
            modelo.idPartido = item.idPartido;
            modelo.idLiga = item.idLiga;
            modelo.idEquipoLocal = item.idEquipoLocal;
            modelo.idEquipoVisitante = item.idEquipoVisitante;
            modelo.Date = item.Date;
            modelo.idCampo = item.idCampo;
            modelo.idLive = item.idLive;
            modelo.idArbitro = item.idArbitro;
            modelo.isJugado = item.isJugado;
            return modelo;
        }
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cPartidos coleccion = new Domain.Collections.cPartidos();
            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }


        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cPartidos coleccion = new Domain.Collections.cPartidos();
            ViewBag.Title = "Seleccionar partido";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }


        public ActionResult Gestion(int id, int idLiga)
        {
            gPartidos item = new gPartidos();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gPartidos(id);
                if (!item.exist) return HttpNotFound();
            }
            ViewBag.idLiga = idLiga;
            ViewBag.idPartido = id;
            ViewBag.NuevoPartido = !item.exist;

            return View();
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gPartidos item = new gPartidos(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate(int id)
        {

            ViewBag.Equipos = new cEquipos().List(id);
            ViewBag.Campos = new cCampos().showAllResults();
            ViewBag.Arbitros = new cArbitros().showAllResults();
            ViewBag.idLiga = id;
            return PartialView("_AjaxCreate", new Partidos());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Partidos modelo)
        {
            ViewBag.Equipos = new cEquipos().List((int)modelo.idLiga);
            ViewBag.Campos = new cCampos().showAllResults();
            ViewBag.Arbitros = new cArbitros().showAllResults();
            ViewBag.idLiga = (int)modelo.idLiga;
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();
                if (modelo.idEquipoLocal == modelo.idEquipoVisitante)
                {

                    ViewBag.ErrorMensaje = "Los equipos no pueden enfrentarse a si mismos.";
                }
                else
                {
                    gPartidos item = new gPartidos();
                    item.idLiga = modelo.idLiga;
                    item.idEquipoLocal = modelo.idEquipoLocal;
                    item.idEquipoVisitante = modelo.idEquipoVisitante;
                    item.Date = modelo.Date;
                    item.idCampo = modelo.idCampo;
                    item.idLive = modelo.idLive;
                    item.idArbitro = modelo.idArbitro;
                    item.isJugado = modelo.isJugado;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Index", "Partidos", new { id = item.idPartido });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El partido no ha podido ser creado.";
                    }
                }                
            }
            return PartialView("_AjaxCreate", modelo);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idPartido)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gPartidos item = new gPartidos(idPartido);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Partidos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gPartidos item = new gPartidos(modelo.idPartido);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El partido seleccionado no es válido.";
                }
                else
                {
                    item.idLiga = modelo.idLiga;
                    item.idEquipoLocal = modelo.idEquipoLocal;
                    item.idEquipoVisitante = modelo.idEquipoVisitante;
                    item.Date = modelo.Date;
                    item.idCampo = modelo.idCampo;
                    item.idLive = modelo.idLive;
                    item.idArbitro = modelo.idArbitro;
                    item.isJugado = modelo.isJugado;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Partidos", new { id = item.idPartido });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El partidos seleccionado no ha podido ser editado";
                    }

                }
            }
            return PartialView("_AjaxEdit", modelo);
        }



        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gPartidos gPartido = new gPartidos(id);
            if (!gPartido.exist) return HttpNotFound();

            ViewBag.id = gPartido.idPartido;

            return PartialView("_Delete");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gPartidos gPartido = new gPartidos(id);
            if (!gPartido.exist)
            {
                result.messaje = "El partido seleccionado no es valido";
            }
            else
            {
                gPartido.Quitar(id);
                result.success = gPartido.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El partido seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

        public ActionResult borrarPartidoNoJugado(int id)
        {
            gPartidos gPartido = new gPartidos(id);
            int idLiga = (int)gPartido.idLiga;
            gPartido.Quitar(id);
            return RedirectToAction("Calendario", "Partidos", new { idLiga = idLiga });
        }

        public ActionResult Calendario(int idLiga)
        {
            ViewBag.LigaId = idLiga;

            return View(new cPartidos().List(idLiga));
        }

        public ActionResult Resultados(int idLiga)
        {
            ViewBag.LigaId = idLiga;

            return View(new cPartidos().ListResultados(idLiga));
        }

        public ActionResult introResultados()
        {
            return View(new cPartidos().listaSinJugar());
        }

        public ActionResult partidosLive()
        {
            return View(new cPartidos().listaConLive());
        }
    }
}