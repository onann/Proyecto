
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Jugadores;
using System.Web.Routing;
using Domain.Collections;

namespace Proyecto.Controllers
{
    public class JugadoresController : Controller
    {
        private Jugadores obtenerModelo(gJugadores item)
        {

            Jugadores modelo = new Jugadores();
            modelo.idJugador = item.idJugador;
            modelo.Nombre = item.Nombre;
            modelo.idEquipo = item.idEquipo;
            modelo.Apellido1 = item.Apellido1;
            modelo.Apellido2 = item.Apellido2;
            modelo.Fecha_Nacimiento = item.Fecha_Nacimiento;
            modelo.Altura = item.Altura;
            modelo.Peso = item.Peso;
            modelo.Puntos = item.Puntos;
            modelo.Partidos_Jugados = item.Partidos_Jugados;
            modelo.Partidos_Ganados = item.Partidos_Ganados;
            modelo.Partidos_Perdidos = item.Partidos_Perdidos;
            modelo.Partidos_Empatados = item.Partidos_Empatados;
            modelo.TarjetasAmarillas = item.TarjetasAmarillas;
            modelo.TarjetasRojas = item.TarjetasRojas;
            return modelo;
        }


        // GET: Clubes
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cJugadores coleccion = new Domain.Collections.cJugadores();

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
            Domain.Collections.cJugadores coleccion = new Domain.Collections.cJugadores();
            ViewBag.Title = "Seleccionar Jugador";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gJugadores item = new gJugadores();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gJugadores(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idJugador = id;
            ViewBag.NuevoJugador = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gJugadores item = new gJugadores(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Jugadores());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Jugadores modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gJugadores item = new gJugadores();
                item.Nombre = modelo.Nombre;
                item.idEquipo = modelo.idEquipo;
                item.Apellido1 = item.Apellido1;
                item.Apellido2 = modelo.Apellido2;
                item.Fecha_Nacimiento = modelo.Fecha_Nacimiento;
                item.Altura = modelo.Altura;
                item.Peso = modelo.Peso;
                item.Puntos = modelo.Puntos;
                item.Partidos_Jugados = modelo.Partidos_Jugados;
                item.Partidos_Ganados = modelo.Partidos_Ganados;
                item.Partidos_Perdidos = modelo.Partidos_Perdidos;
                item.Partidos_Empatados = modelo.Partidos_Empatados;
                item.TarjetasAmarillas = modelo.TarjetasAmarillas;
                item.TarjetasRojas = modelo.TarjetasRojas;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Jugadores", new { id = item.idJugador });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El jugador no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idJugador)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gJugadores item = new gJugadores(idJugador);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Jugadores modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gJugadores item = new gJugadores(modelo.idJugador);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El jugador seleccionado no es válido.";
                }
                else
                {
                    item.Nombre = modelo.Nombre;
                    item.idEquipo = modelo.idEquipo;
                    item.Apellido1 = item.Apellido1;
                    item.Apellido2 = modelo.Apellido2;
                    item.Fecha_Nacimiento = modelo.Fecha_Nacimiento;
                    item.Altura = modelo.Altura;
                    item.Peso = modelo.Peso;
                    item.Puntos = modelo.Puntos;
                    item.Partidos_Jugados = modelo.Partidos_Jugados;
                    item.Partidos_Ganados = modelo.Partidos_Ganados;
                    item.Partidos_Perdidos = modelo.Partidos_Perdidos;
                    item.Partidos_Empatados = modelo.Partidos_Empatados;
                    item.TarjetasAmarillas = modelo.TarjetasAmarillas;
                    item.TarjetasRojas = modelo.TarjetasRojas;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Jugadores", new { id = item.idJugador });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El jugador seleccionado no ha podido ser editado";
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

            gJugadores gJugador = new gJugadores(id);
            if (!gJugador.exist) return HttpNotFound();

            ViewBag.id = gJugador.idJugador;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gJugadores gJugador = new gJugadores(id);
            if (!gJugador.exist)
            {
                result.messaje = "El jugador seleccionado no es valido";
            }
            else
            {
                gJugador.Quitar(id);
                result.success = gJugador.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El jugador seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

       
    }
}