
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

            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cEstadisticasPartidos coleccion = new Domain.Collections.cEstadisticasPartidos();

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
            Domain.Collections.cEstadisticasPartidos coleccion = new Domain.Collections.cEstadisticasPartidos();
            ViewBag.Title = "Seleccionar EstadisticasPartidos";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

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

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEstadisticasPartidos item = new gEstadisticasPartidos(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate(int id)
        {
            gPartidos partido = new gPartidos(id);
            ViewBag.idPartido = id; //recibimos el id partido
            ViewBag.idEquipoVisitante = partido.getIdLocal(id);
            ViewBag.idEquipoLocal = partido.getIdVisitante(id);


            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new EstadisticasPartidos());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(EstadisticasPartidos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gEstadisticasPartidos item = new gEstadisticasPartidos();
                item.idPartido = modelo.idPartido;
                item.idEquipo = modelo.idEquipo;
                item.Ensayos = modelo.Ensayos;
                item.Conversiones = modelo.Conversiones;
                item.GolpesCastigo = modelo.GolpesCastigo;
                item.Drops = modelo.Drops;
                item.TarjetasAmarillas = modelo.TarjetasAmarillas;
                item.TarjetasRojas = modelo.TarjetasRojas;

                gEstadisticasPartidos item2 = new gEstadisticasPartidos();
                item2.idPartido = modelo.idPartido2;
                item2.idEquipo = modelo.idEquipo2;
                item2.Ensayos = modelo.Ensayos2;
                item2.Conversiones = modelo.Conversiones2;
                item2.GolpesCastigo = modelo.GolpesCastigo2;
                item2.Drops = modelo.Drops2;
                item2.TarjetasAmarillas = modelo.TarjetasAmarillas2;
                item2.TarjetasRojas = modelo.TarjetasRojas2;


                result.success = item.save();
                if (result.success)
                {
                    result.success = item2.save();
                    if (result.success)
                    {
                        result.redirect = Url.Action("Index", "EstadisticasPartidos", new { id = item.idEstadistica_Partido });
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

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idEstadistica_Partido)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEstadisticasPartidos item = new gEstadisticasPartidos(idEstadistica_Partido);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

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


        // GET: /License/AjaxDelete

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gEstadisticasPartidos gEstadistica = new gEstadisticasPartidos(id);
            if (!gEstadistica.exist) return HttpNotFound();

            ViewBag.id = gEstadistica.idEstadistica_Partido;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gEstadisticasPartidos gEstadistica = new gEstadisticasPartidos(id);
            if (!gEstadistica.exist)
            {
                result.messaje = "La estadistica seleccionada no es valida";
            }
            else
            {
                gEstadistica.Quitar(id);
                result.success = gEstadistica.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "La estadistica seleccionada  no ha podido ser borrada";
            }

            return Json(result);
        }
    }
}