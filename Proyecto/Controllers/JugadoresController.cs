
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
            return modelo;
        }

        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cJugadores coleccion = new Domain.Collections.cJugadores();

            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }

        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cJugadores coleccion = new Domain.Collections.cJugadores();
            ViewBag.Title = "Seleccionar Jugador";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        public ActionResult Gestion(int id, int idEquipo)
        {
            gJugadores item = new gJugadores();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gJugadores(id);
                if (!item.exist) return HttpNotFound();
            }
            ViewBag.idEquipo = idEquipo;
            ViewBag.idJugador = id;
            ViewBag.NuevoJugador = !item.exist;

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gJugadores item = new gJugadores(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate(int id)
        {
            ViewBag.Equipos = new cEquipos().showAllResults();
            ViewBag.idEquipo = id;

            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Jugadores());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Jugadores modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            
            if (ModelState.IsValid)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - Convert.ToDateTime(modelo.fechaIntroducida).Year;
                if (age < 18)
                {
                    ViewBag.ErrorMensaje = "El jugador tiene que ser mayor de edad.";
                }
                else
                {
                    if ((modelo.Altura > 230 || modelo.Altura < 140) || (modelo.Peso > 160) || (modelo.Peso < 45))
                    {
                        ViewBag.ErrorMensaje = "La altura o peso son incorrectas.";
                    }
                    else
                    {
                        var result = new Domain.Definitions.cJsonResultData();

                        gJugadores item = new gJugadores();
                        item.Nombre = modelo.Nombre;
                        item.idEquipo = modelo.idEquipo;
                        item.Apellido1 = modelo.Apellido1;
                        item.Apellido2 = modelo.Apellido2;
                        item.Fecha_Nacimiento = Convert.ToDateTime(modelo.fechaIntroducida);
                        item.Altura = modelo.Altura;
                        item.Peso = modelo.Peso;

                        result.success = item.save();

                        if (result.success)
                        {
                            result.redirect = Url.Action("listaJugadores", "Equipos", new { idEquipo = modelo.idEquipo });
                            return Json(result);
                        }
                        else
                        {
                            ViewBag.ErrorMensaje = "El jugador no ha podido ser creado.";
                        }
                    }
                }
            }

            return PartialView("_AjaxCreate", modelo);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idJugador)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gJugadores item = new gJugadores(idJugador);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

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

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gJugadores gJugador = new gJugadores(id);
            if (!gJugador.exist) return HttpNotFound();

            ViewBag.id = gJugador.idJugador;

            return PartialView("_Delete");
        }

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