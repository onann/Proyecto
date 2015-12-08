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


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cPartidos coleccion = new Domain.Collections.cPartidos();

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
            Domain.Collections.cPartidos coleccion = new Domain.Collections.cPartidos();
            ViewBag.Title = "Seleccionar partido";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

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

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gPartidos item = new gPartidos(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate(int id)
        {

            ViewBag.Equipos = new cEquipos().List(id);
            ViewBag.Campos = new cCampos().showAllResults();
            ViewBag.Arbitros = new cArbitros().showAllResults();
            ViewBag.idLiga = id;

            //if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Partidos());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Partidos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

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

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idPartido)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gPartidos item = new gPartidos(idPartido);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

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


        // GET: /License/AjaxDelete

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gPartidos gPartido = new gPartidos(id);
            if (!gPartido.exist) return HttpNotFound();

            ViewBag.id = gPartido.idPartido;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

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

        public ActionResult Calendario(int idLiga)
        {
            ViewBag.LigaId = idLiga;
            //ViewBag.ItemId = item;

            return View(new cPartidos().List(idLiga));
        }

        public ActionResult Resultados(int idLiga)
        {
            ViewBag.LigaId = idLiga;
            //ViewBag.ItemId = item;

            return View(new cPartidos().ListResultados(idLiga));
        }

        public ActionResult introResultados()
        {
            return View(new cPartidos().listaSinJugar());
        }
    }
}