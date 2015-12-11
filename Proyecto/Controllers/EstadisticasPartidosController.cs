
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.EstadisticasPartidos;
using System.Web.Routing;
using Domain.Collections;

namespace Proyecto.Controllers
{
    public class EstadisticasPartidosController : Controller
    {
        private EstadisticasPartidos obtenerModelo(gEstadisticasPartidos item)
        {

            EstadisticasPartidos modelo = new EstadisticasPartidos();
            modelo.idEstadistica_Partido = item.idEstadistica_Partido;
            modelo.idPartido = item.idPartido;
            modelo.idEquipo = item.idEquipo;
            modelo.Ensayos = item.Ensayos;
            modelo.Conversiones = item.Conversiones;
            modelo.GolpesCastigo = item.GolpesCastigo;
            modelo.Drops = item.Drops;
            modelo.TarjetasAmarillas = item.TarjetasAmarillas;
            modelo.TarjetasRojas = item.TarjetasRojas;
            modelo.Marcador = item.Marcador;

            return modelo;
        }


        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cEstadisticasPartidos coleccion = new Domain.Collections.cEstadisticasPartidos();

            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }


        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cEstadisticasPartidos coleccion = new Domain.Collections.cEstadisticasPartidos();
            ViewBag.Title = "Seleccionar EstadisticasPartidos";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        public ActionResult Gestion(int id, int idPartido)
        {
            gEstadisticasPartidos item = new gEstadisticasPartidos();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gEstadisticasPartidos(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idPartido = idPartido;
            ViewBag.NuevaEstadisticaPartido = !item.exist;

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEstadisticasPartidos item = new gEstadisticasPartidos(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate(int id)
        {
            gPartidos partido = new gPartidos(id);
            ViewBag.idPartido = id;
            ViewBag.idEquipoVisitante = partido.getIdLocal(id);
            ViewBag.idEquipoLocal = partido.getIdVisitante(id);

            gEquipos equipo = new gEquipos(partido.getIdLocal(id));
            gEquipos equipo2 = new gEquipos(partido.getIdVisitante(id));
            ViewBag.nombreLocal = equipo.Nombre;
            ViewBag.nombreVisitante = equipo2.Nombre;

            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new EstadisticasPartidos());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(EstadisticasPartidos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            if (modelo.Conversiones > modelo.Ensayos || modelo.Conversiones2 > modelo.Ensayos2)
            {
                gPartidos partido = new gPartidos(modelo.idPartido);
                ViewBag.idPartido = modelo.idPartido;
                ViewBag.idEquipoVisitante = partido.getIdLocal(modelo.idPartido);
                ViewBag.idEquipoLocal = partido.getIdVisitante(modelo.idPartido);
                ViewBag.ErrorMensaje = "No puede haber mas conversiones que ensayos.";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var result = new Domain.Definitions.cJsonResultData();

                    gEstadisticasPartidos item = new gEstadisticasPartidos();
                    item.idPartido = modelo.idPartido;
                    item.idEquipo = modelo.idEquipo;
                    item.Ensayos = modelo.Ensayos ?? 0;
                    item.Conversiones = modelo.Conversiones ?? 0;
                    item.GolpesCastigo = modelo.GolpesCastigo ?? 0;
                    item.Drops = modelo.Drops ?? 0;
                    item.TarjetasAmarillas = modelo.TarjetasAmarillas ?? 0;
                    item.TarjetasRojas = modelo.TarjetasRojas ?? 0;
                    item.Marcador = (int)(((modelo.Ensayos ?? 0) * 5) + ((modelo.Conversiones ?? 0) * 2) + ((modelo.Drops ?? 0) * 3) + ((modelo.GolpesCastigo ?? 0) * 3));

                    gEstadisticasPartidos item2 = new gEstadisticasPartidos();
                    item2.idPartido = modelo.idPartido2;
                    item2.idEquipo = modelo.idEquipo2;
                    item2.Ensayos = modelo.Ensayos2 ?? 0;
                    item2.Conversiones = modelo.Conversiones2 ?? 0;
                    item2.GolpesCastigo = modelo.GolpesCastigo2 ?? 0;
                    item2.Drops = modelo.Drops2 ?? 0;
                    item2.TarjetasAmarillas = modelo.TarjetasAmarillas2 ?? 0;
                    item2.TarjetasRojas = modelo.TarjetasRojas2 ?? 0;
                    item2.Marcador = (int)(((modelo.Ensayos2 ?? 0) * 5) + ((modelo.Conversiones2 ?? 0) * 2) + ((modelo.Drops2 ?? 0) * 3) + ((modelo.GolpesCastigo2 ?? 0) * 3));


                    result.success = item.save();
                    if (result.success)
                    {
                        result.success = item2.save();
                        if (result.success)
                        {
                            gEquipos equipo1 = new gEquipos(item.idEquipo);
                            gEquipos equipo2 = new gEquipos(item2.idEquipo);
                            equipo1.guardarEstadisticas(item.idPartido);
                            equipo2.guardarEstadisticas(item2.idPartido);

                            gPartidos partido = new gPartidos(item.idPartido);
                            partido.isJugado = true;

                            partido.save();

                            gArbitros arbitro = new gArbitros((int)partido.getIdArbitro());
                            arbitro.Partidos += 1;
                            arbitro.TarjetasAmarillas += (modelo.TarjetasAmarillas + modelo.TarjetasAmarillas2);
                            arbitro.TarjetasRojas += (modelo.TarjetasRojas + modelo.TarjetasRojas2);
                            arbitro.save();
                            result.redirect = Url.Action("introResultados", "Partidos", null);
                            
                            return Json(result);
                        }
                        else
                        {
                            ViewBag.ErrorMensaje = "La estadistica no ha podido ser creada.";
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "La estadistica no ha podido ser creada.";
                    }
                }
            }

            return PartialView("_AjaxCreate", modelo);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idEstadistica_Partido)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEstadisticasPartidos item = new gEstadisticasPartidos(idEstadistica_Partido);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(EstadisticasPartidos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gEstadisticasPartidos item = new gEstadisticasPartidos(modelo.idEstadistica_Partido);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "La estadistica seleccionada no es válida.";
                }
                else
                {
                    item.idEquipo = modelo.idEquipo;
                    item.Ensayos = modelo.Ensayos;
                    item.Conversiones = modelo.Conversiones;
                    item.GolpesCastigo = modelo.GolpesCastigo;
                    item.Drops = modelo.Drops;
                    item.TarjetasAmarillas = modelo.TarjetasAmarillas;
                    item.TarjetasRojas = modelo.TarjetasRojas;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "EstadisticasPartidos", new { id = item.idEstadistica_Partido });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "La estadistica seleccionada no ha podido ser editada";
                    }

                }
            }
            return PartialView("_AjaxEdit", modelo);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEstadisticasPartidos gEstadistica = new gEstadisticasPartidos(id);
            if (!gEstadistica.exist) return HttpNotFound();

            ViewBag.id = gEstadistica.idEstadistica_Partido;

            return PartialView("_Delete");
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gPartidos partido = new gPartidos(id);
            gEquipos equipo1 = new gEquipos(partido.getIdLocal(partido.idPartido));
            equipo1.restarEstadisticas(partido.idPartido);
            gEquipos equipo2 = new gEquipos(partido.getIdVisitante(partido.idPartido));
            equipo2.restarEstadisticas(partido.idPartido);

            gArbitros arbitro = new gArbitros((int)partido.getIdArbitro());
            arbitro.Partidos -= 1;

            var estadisticas = partido.getEstadisticasPartido();
            foreach (var i in estadisticas)
            {
                gEstadisticasPartidos gEstadistica = new gEstadisticasPartidos(i);
                if (!gEstadistica.exist)
                {
                    result.messaje = "La estadistica seleccionada no es valida";
                }
                else
                {

                    arbitro.TarjetasAmarillas -= (gEstadistica.TarjetasAmarillas);
                    arbitro.TarjetasRojas -= (gEstadistica.TarjetasRojas);
                    arbitro.save();

                    gEstadistica.Quitar(i);
                    result.success = gEstadistica.save();
                    result.reload = result.success;
                    if (!result.success) result.messaje = "La estadistica seleccionada  no ha podido ser borrada";
                    
                }

                
            }
            partido.isJugado = false;
            partido.save();
            return Json(result);
        }

             
        public ActionResult borrarResultado(int id)
        {

            gPartidos partido = new gPartidos(id);
            gEquipos equipo1 = new gEquipos(partido.getIdLocal(partido.idPartido));
            equipo1.restarEstadisticas(partido.idPartido);
            gEquipos equipo2 = new gEquipos(partido.getIdVisitante(partido.idPartido));
            equipo2.restarEstadisticas(partido.idPartido);

            gArbitros arbitro = new gArbitros((int)partido.getIdArbitro());
            arbitro.Partidos -= 1;

            var estadisticas = partido.getEstadisticasPartido();
            foreach (var i in estadisticas)
            {
                gEstadisticasPartidos gEstadistica = new gEstadisticasPartidos(i);
               

                    arbitro.TarjetasAmarillas -= (gEstadistica.TarjetasAmarillas);
                    arbitro.TarjetasRojas -= (gEstadistica.TarjetasRojas);
                    arbitro.save();

                    gEstadistica.Quitar(i);
                    gEstadistica.save();
                    
                    
              
                
            }
            partido.isJugado = false;
            partido.save();
            return RedirectToAction("Resultados", "Partidos", new { idLiga = partido.idLiga });
        }
    }
}