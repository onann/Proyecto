using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Gestion;
using Proyecto.Models.Ligas;
using Domain.Collections;

namespace AMS.Controllers
{
    public class LigasController : Controller
    {

        public ActionResult Index(string search)
        {
            return View(new cLigas().List(search, User.IsInRole(Domain.Definitions.eRolesUsers.Administrador.ToString())).OrderBy(x => x.nombre));
        }

        public ActionResult HeadInfo(int id)
        {
            var item = new gLigas(id);
            if (item.exist)
            {
                ViewBag.MessageTitle = item.nombre;
                ViewBag.MessageContent = item.getNombreCategoria();
            }
            else
            {
                ViewBag.MessageTitle = "Nueva Liga";
                ViewBag.MessageContent = "Introduzca los datos de la nueva liga";
            }

            return PartialView("_HeadInfo");
        }

        public ActionResult Properties(int id)
        {
            var model = new Ligas();

            if (id < 0) return HttpNotFound();

            var item = new gLigas(id);

            model.idLiga = item.idLiga;
            model.idCategoriaLiga = item.idCategoriaLiga;
            model.nombre = item.nombre;

            ViewBag.LigaId = item.idLiga;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Properties(Ligas model)
        {
            if (ModelState.IsValid)
            {
                var item = new gLigas(model.idLiga);
                item.idCategoriaLiga = model.idCategoriaLiga;
                item.nombre = model.nombre;
                
                if (item.save())
                {
                    return RedirectToAction("Properties", new { id = item.idLiga });
                }
                else { ViewBag.MessageError = "No se ha podido completar la operación solicitada"; }
            }

            return View(model);
        }       

        public ActionResult Clasificacion(int idLiga)
        {
            ViewBag.LigaId = idLiga;

            return View(new cLigas().List(idLiga));
        }

        public ActionResult FillEquipos(int idLiga)
        {
            var equipos = new cEquipos().List(idLiga);
            return Json(equipos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult selector()
        {
            return View(new cLigas().listaNombres());
        }

    }
}