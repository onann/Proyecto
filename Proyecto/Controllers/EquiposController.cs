
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Equipos;
using System.Web.Routing;
using Domain.Collections;

namespace Proyecto.Controllers
{
    public class EquiposController : Controller
    {
        private Equipos obtenerModelo(gEquipos item)
        {

            Equipos modelo = new Equipos();
            modelo.idEquipo = item.idEquipo;
            modelo.idClub = item.idClub;
            modelo.Nombre = item.Nombre;
            modelo.idLiga = item.idLiga;
            modelo.Puntos = item.Puntos;
            modelo.Partidos_Jugados = item.Partidos_Jugados;
            modelo.Partidos_Ganados = item.Partidos_Ganados;
            modelo.Partidos_Perdidos = item.Partidos_Perdidos;
            modelo.Partidos_Empatados = item.Partidos_Empatados;
            modelo.Puntos_Encajados = item.Puntos_Encajados;
            modelo.Puntos_Anotados = item.Puntos_Anotados;

            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cEquipos coleccion = new Domain.Collections.cEquipos();

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
            Domain.Collections.cEquipos coleccion = new Domain.Collections.cEquipos();
            ViewBag.Title = "Seleccionar Equipo";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gEquipos item = new gEquipos();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gEquipos(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idEquipo = id;
            ViewBag.NuevoEquipo = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEquipos item = new gEquipos(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            ViewBag.Clubes = new cClubes().showAllResults();
            ViewBag.Ligas = new cLigas().showAllResults();

            return PartialView("_AjaxCreate", new Equipos());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Equipos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gEquipos item = new gEquipos();
                item.idClub = modelo.idClub;
                item.Nombre = modelo.Nombre;
                item.idLiga = modelo.idLiga;
                item.Puntos = modelo.Puntos;
                item.Partidos_Jugados = modelo.Partidos_Jugados;
                item.Partidos_Ganados = modelo.Partidos_Ganados;
                item.Partidos_Perdidos = modelo.Partidos_Perdidos;
                item.Partidos_Empatados = modelo.Partidos_Empatados;
                item.Puntos_Encajados = modelo.Puntos_Encajados;
                item.Puntos_Anotados = modelo.Puntos_Anotados;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Equipos", new { id = item.idEquipo });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El equipo no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idEquipo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEquipos item = new gEquipos(idEquipo);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Equipos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gEquipos item = new gEquipos(modelo.idEquipo);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El equipo seleccionado no es válido.";
                }
                else
                {
                    item.idClub = modelo.idClub;
                    item.Nombre = modelo.Nombre;
                    item.idLiga = modelo.idLiga;
                    item.Puntos = modelo.Puntos;
                    item.Partidos_Jugados = modelo.Partidos_Jugados;
                    item.Partidos_Ganados = modelo.Partidos_Ganados;
                    item.Partidos_Perdidos = modelo.Partidos_Perdidos;
                    item.Partidos_Empatados = modelo.Partidos_Empatados;
                    item.Puntos_Encajados = modelo.Puntos_Encajados;
                    item.Puntos_Anotados = modelo.Puntos_Anotados;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Equipos", new { id = item.idEquipo });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El equipo seleccionado no ha podido ser editado";
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

            gEquipos gEquipo = new gEquipos(id);
            if (!gEquipo.exist) return HttpNotFound();

            ViewBag.id = gEquipo.idEquipo;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gEquipos gEquipo = new gEquipos(id);
            if (!gEquipo.exist)
            {
                result.messaje = "El Equipo seleccionado no es valido";
            }
            else
            {
                gEquipo.Quitar(id);
                result.success = gEquipo.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El Equipo seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

        //public ActionResult AjaxByClient(int idLiga)
        //{
        //    if (!Request.IsAjaxRequest()) return HttpNotFound();

        //    Domain.Collections.cEquipos Coleccion = new Domain.Collections.cEquipos();
        //    return PartialView("_AjaxByClient", Coleccion.mostrarEquiposLiga(idLiga));
        //}

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Lista(int idLiga)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gLigas item = new gLigas(idLiga);
            if (!item.exist) return HttpNotFound();

            ViewBag.idLiga = item.idLiga;
            //ViewBag.SoloLectura = item.deleted;

            Domain.Collections.cEquipos coleccion = new Domain.Collections.cEquipos();

            return PartialView("_Lista", coleccion.List(idLiga).OrderBy(m => m.Nombre));
        }


        // GET : /Catalogs/HeadInfo/

        public ActionResult HeadInfo(int id)
        {
            var item = new gEquipos(id);
            if (item.exist)
            {
                ViewBag.MessageTitle = item.Nombre;
                ViewBag.MessageContent = item.Nombre;
            }
            else
            {
                ViewBag.MessageTitle = "Nuevo equipo";
                ViewBag.MessageContent = "Introduzca los datos del nuevo equipo";
            }

            return PartialView("_HeadInfo");
        }



        // GET : /Catalogs/Properties/

        public ActionResult Properties(int id)
        {
            var model = new Equipos();

            if (id < 0) return HttpNotFound();

            var item = new gEquipos(id);

            //if (item.Deleted) return HttpNotFound();

            model.idEquipo = item.idEquipo;
            model.idClub = item.idClub;
            model.Nombre = item.Nombre;

            ViewBag.EquipoId = item.idEquipo;

            return View(model);
        }


        // POST : /Catalogs/Properties/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Properties(Equipos model)
        {
            if (ModelState.IsValid)
            {
                var item = new gEquipos(model.idEquipo);
                item.idClub = model.idClub;
                item.Nombre = model.Nombre;

                //if (item.Save()) { return RedirectToAction("Index"); }
                //else { ViewBag.MessageError = "No se ha podido completar la operación solicitada"; }
                
                if (item.save())
                {
                    return RedirectToAction("Properties", new { id = item.idEquipo });
                }
                else { ViewBag.MessageError = "No se ha podido completar la operación solicitada"; }
            }

            return View(model);
        }

        public ActionResult listaJugadores(int idEquipo)
        {
            ViewBag.EquipoId = idEquipo;
            //ViewBag.ItemId = item;

            return View(new cJugadores().List(idEquipo));
        }

        public ActionResult Estadisticas(int idEquipo)
        {
            ViewBag.EquipoId = idEquipo;
            //ViewBag.ItemId = item;

            return View(new cEstadisticasPartidos().estadisticasEquipo(idEquipo));
        }

        public ActionResult Campos(int idEquipo)
        {
            ViewBag.EquipoId = idEquipo;
            //ViewBag.ItemId = item;

            return View(new cCampos().camposEquipo(idEquipo));
        }


    }
}