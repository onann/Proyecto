using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Campos;
using System.Web.Routing;

namespace Proyecto.Controllers
{
    public class CamposController : Controller
    {
        private Campos obtenerModelo(gCampos item)
        {

            Campos modelo = new Campos();
            modelo.idCampo = item.idCampo;
            modelo.idEquipo = item.idEquipo;
            modelo.Nombre = item.nombre;
            modelo.Direccion = item.Direccion;

            return modelo;
        }


        // GET: Campos
        public ActionResult Index(string searchStr)
        {
            Domain.Collections.cCampos coleccion = new Domain.Collections.cCampos();

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
            Domain.Collections.cCampos coleccion = new Domain.Collections.cCampos();
            ViewBag.Title = "Seleccionar Campo";
            return View(searchStr != null ? coleccion.showResults(searchStr) : coleccion.showResults());
        }

        // GET: /License/Gestion

        public ActionResult Gestion(int id)
        {
            gCampos item = new gCampos();
            if (id < -1) return HttpNotFound();


            if (id > -1)
            {
                item = new gCampos(id);
                if (!item.exist) return HttpNotFound();
            }

            ViewBag.idCampo = id;
            ViewBag.NuevoCampo = !item.exist;

            return View();
        }

        // GET: /License/AjaxDetails/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxDetails(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCampos item = new gCampos(id);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxDetails", item);
        }

        // GET: /License/AjaxCreate

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxCreate()
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();
            return PartialView("_AjaxCreate", new Campos());
        }

        // POST: /License/AjaxCreate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxCreate(Campos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gCampos item = new gCampos();
                item.idEquipo = modelo.idEquipo;
                item.nombre = modelo.Nombre;
                item.Direccion = modelo.Direccion;

                result.success = item.save();

                if (result.success)
                {
                    result.redirect = Url.Action("Index", "Campos", new { id = item.idCampo });
                    return Json(result);
                }
                else
                {
                    ViewBag.ErrorMensaje = "El campo no ha podido ser creado.";
                }

            }

            return PartialView("_AjaxCreate", modelo);
        }

        // GET: /License/AjaxEdit

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AjaxEdit(int idCampo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            gCampos item = new gCampos(idCampo);
            if (!item.exist) return HttpNotFound();

            return PartialView("_AjaxEdit", obtenerModelo(item));
        }

        // POST: /License/AjaxEdit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxEdit(Campos modelo)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            if (ModelState.IsValid)
            {
                var result = new Domain.Definitions.cJsonResultData();

                gCampos item = new gCampos(modelo.idCampo);
                if (!item.exist)
                {
                    ViewBag.ErrorMensaje = "El campo seleccionado no es válido.";
                }
                else
                {
                    item.idEquipo = modelo.idEquipo;
                    item.nombre = modelo.Nombre;
                    item.Direccion = modelo.Direccion;

                    result.success = item.save();

                    if (result.success)
                    {
                        result.redirect = Url.Action("Gestion", "Campos", new { id = item.idCampo });
                        return Json(result);
                    }
                    else
                    {
                        ViewBag.ErrorMensaje = "El campo seleccionado no ha podido ser editado";
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

            gCampos gCampo = new gCampos(id);
            if (!gCampo.exist) return HttpNotFound();

            ViewBag.id = gCampo.idCampo;

            return PartialView("_Delete");
        }


        // POST: /License/AjaxDelete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxDeleteConfirmed(int id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();

            gCampos gCampo = new gCampos(id);
            if (!gCampo.exist)
            {
                result.messaje = "El campo seleccionado no es valido";
            }
            else
            {
                gCampo.Quitar(id);
                result.success = gCampo.save();
                Console.WriteLine(result);
                Console.WriteLine(result.success);
                result.reload = result.success;

                if (!result.success) result.messaje = "El campo seleccionado no ha podido ser borrado";
            }

            return Json(result);
        }

    }
}