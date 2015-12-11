using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Arbitros;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class ArbitrosController : Controller
    {
        private Arbitros obtenerModelo(gArbitros  item)
        {

            Arbitros modelo = new Arbitros();
            modelo.idArbitro = item.idArbitro;
            modelo.Nombre = item.Nombre;
            modelo.Apellido1 = item.Apellido1;
            modelo.Apellido2 = item.Apellido2;
            modelo.Fecha_Nacimiento = item.Fecha_Nacimiento;
            modelo.Partidos = item.Partidos;
            modelo.TarjetasAmarillas = item.TarjetasAmarillas;
            modelo.TarjetasRojas = item.TarjetasRojas;

            return modelo;
        }

        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cArbitros coleccion = new Domain.Collections.cArbitros();
            return View(searchStr != null ? coleccion.showAllResults(searchStr) : coleccion.showAllResults());
        }


        public ActionResult Selector(string searchStr)
        {
            Domain.Collections.cArbitros coleccion = new Domain.Collections.cArbitros();
            ViewBag.Title = "Seleccionar Arbitro";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }


        public ActionResult Gestion(int id)
        {
            gArbitros item = new gArbitros();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gArbitros(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idArbitro = id;
            ViewBag.NuevoArbitro = !item.exist;

            return View();
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gArbitros item = new gArbitros(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Arbitros());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Arbitros modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gArbitros item = new gArbitros();
                item.Nombre = modelo.Nombre;
                item.Apellido1 = modelo.Apellido1;
                item.Apellido2 = modelo.Apellido2;
                item.Fecha_Nacimiento = Convert.ToDateTime(modelo.fechaIntroducida);
                item.Partidos = modelo.Partidos;
                item.TarjetasAmarillas = modelo.TarjetasAmarillas;
                item.TarjetasRojas = modelo.TarjetasRojas;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Arbitros", new { id = item.idArbitro });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El Arbitro no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }


        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idArbitro)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gArbitros item = new gArbitros(idArbitro);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Arbitros modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gArbitros item = new gArbitros(modelo.idArbitro);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El Arbitro seleccionado no es válido.";
                }
                else
                {
                    item.Nombre = modelo.Nombre;
                    item.Apellido1 = modelo.Apellido1;
                    item.Apellido2 = modelo.Apellido2;
                    item.Fecha_Nacimiento = modelo.Fecha_Nacimiento;
                    item.Partidos = modelo.Partidos;
                    item.TarjetasAmarillas = modelo.TarjetasAmarillas;
                    item.TarjetasRojas = modelo.TarjetasRojas;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Arbitros", new { id = item.idArbitro });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El arbitro seleccionado no ha podido ser editado";
                    }

                }
            }
            return PartialView("_AjaxEdit", modelo);
        }



        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDelete(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gArbitros gArbitro = new gArbitros(id);
            if (!gArbitro.exist) return HttpNotFound();

            ViewBag.id = gArbitro.idArbitro;

            return PartialView("_Delete");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gArbitros gArbitro = new gArbitros(id);
            if (!gArbitro.exist)
            {
                result.messaje = "El arbitro seleccionado no es valido";
            }
            else
            {
                gArbitro.Quitar(id);
                result.success = gArbitro.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El arbitro seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

    }
}