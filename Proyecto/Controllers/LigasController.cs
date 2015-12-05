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

        // GET: /Catalogs/

        public ActionResult Index(string search)
        {
            return View(new cLigas().List(search, User.IsInRole(Domain.Definitions.eRolesUsers.Administrador.ToString())).OrderBy(x => x.nombre));
        }



        // GET : /Catalogs/HeadInfo/

        public ActionResult HeadInfo(int id)
        {
            var item = new gLigas(id);
            if (item.exist)
            {
                ViewBag.MessageTitle = item.nombre;
                ViewBag.MessageContent = item.nombre;
            }
            else
            {
                ViewBag.MessageTitle = "Nueva Liga";
                ViewBag.MessageContent = "Introduzca los datos de la nueva liga";
            }

            return PartialView("_HeadInfo");
        }


        // GET : /Catalogs/Properties/

        public ActionResult Properties(int id)
        {
            var model = new Ligas();

            if (id < 0) return HttpNotFound();

            var item = new gLigas(id);

            //if (item.Deleted) return HttpNotFound();

            model.idLiga = item.idLiga;
            model.idCategoriaLiga = item.idCategoriaLiga;
            model.nombre = item.nombre;

            ViewBag.LigaId = item.idLiga;

            return View(model);
        }


        // POST : /Catalogs/Properties/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Properties(Ligas model)
        {
            if (ModelState.IsValid)
            {
                var item = new gLigas(model.idLiga);
                item.idCategoriaLiga = model.idCategoriaLiga;
                item.nombre = model.nombre;

                //if (item.Save()) { return RedirectToAction("Index"); }
                //else { ViewBag.MessageError = "No se ha podido completar la operación solicitada"; }
                
                if (item.save())
                {
                    return RedirectToAction("Properties", new { id = item.idLiga });
                }
                else { ViewBag.MessageError = "No se ha podido completar la operación solicitada"; }
            }

            return View(model);
        }

        /*
        // POST : /Catalogs/Enable/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Enable(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();
            var item = new gCatalog(id);

            if (!item.Exist) return HttpNotFound();
            item.Enabled = true;

            result.success = item.Save();

            result.reload = result.success;
            if (!result.success) result.messaje = "No se ha podido completar la operación solicitada.";

            return Json(result);
        }


        // POST : /Catalogs/Disable/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Disable(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();
            var item = new gCatalog(id);

            if (!item.Exist) return HttpNotFound();
            item.Enabled = false;

            result.success = item.Save();

            result.reload = result.success;
            if (!result.success) result.messaje = "No se ha podido completar la operación solicitada.";

            return Json(result);
        }


        // GET : /Catalogs/Delete/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Delete(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var item = new gCatalog(id);
            if (!item.Exist) return HttpNotFound();

            ViewBag.CatalogId = item.Id;
            ViewBag.CatalogName = item.Name;

            return PartialView("_Delete");
        }


        // POST : /Catalogs/Delete/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult DeleteConfirmed(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();
            var item = new gCatalog(id);

            if (!item.Exist) return HttpNotFound();
            item.Deleted = true;

            result.success = item.Save();
            result.reload = result.success;
            if (!result.success) result.messaje = "No se ha podido completar la operación solicitada.";

            return Json(result);
        }


        // GET : /Catalogs/ItemsList/

        public ActionResult ItemsList(long id)
        {
            ViewBag.CatalogId = id;
            return View(new cCatalogItem().List(null, User.IsInRole(Domain.Definitions.eRolesUsers.Administrador.ToString()), id));
        }


        // GET : /Catalogs/ItemsList2/

        public ActionResult ItemsList2(long id)
        {
            return PartialView("_ItemsList2", new cCatalogItem().List(null, User.IsInRole(Domain.Definitions.eRolesUsers.Administrador.ToString()), id));
        }


        // GET : /Catalogs/ItemCategoryList/

        public ActionResult ItemCategoryList(string term)
        {
            return Json(new cCatalogItem().Categories(term), JsonRequestBehavior.AllowGet);
        }


        // GET : /Catalogs/ItemProperties/

        public ActionResult ItemProperties(long catalog, long id)
        {
            var model = new CatalogItemModel();

            if (id < 0) return HttpNotFound();

            var item = new gCatalogItem(id);

            if (item.Deleted) return HttpNotFound();

            model.CatalogId = item.CatalogId;
            model.CatalogName = item.CatalogName;
            model.Category = item.Category;
            model.Description = item.Description;
            model.GracePeriod = item.GracePeriod;
            model.Hash = item.Hash;
            model.Id = item.Id;
            model.Name = item.Name;
            model.Path = item.Path;
            model.ProductId = item.ProductId;
            model.ProductName = item.ProductName;
            model.Icon = item.Icon;
            if (!item.Exist) model.CatalogId = catalog;

            ViewBag.CatalogId = model.CatalogId;

            return View(model);
        }


        // POST : /Catalogs/ItemProperties/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemProperties(CatalogItemModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new gCatalogItem(model.Id);
                item.CatalogId = model.CatalogId;
                item.Category = model.Category;
                item.Description = model.Description;
                item.GracePeriod = model.GracePeriod;
                item.Name = model.Name;
                item.Path = model.Path;
                item.ProductId = model.ProductId;
                item.Icon = null;

                if (model.IconFile != null)
                {
                    var data = new System.IO.MemoryStream();
                    model.IconFile.InputStream.CopyTo(data);
                    item.Icon = data.ToArray();
                }

                if (item.Save())
                {
                    return RedirectToAction("ItemsList", "Catalogs", new { id = item.CatalogId });
                }
                else { ViewBag.MessageError = "No se ha podido completar la operación solicitada"; }
            }

            ViewBag.CatalogId = model.CatalogId;

            return View(model);
        }



        // POST : /Catalogs/ItemEnable/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ItemEnable(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var item = new gCatalogItem(id);

            if (!item.Exist) return HttpNotFound();
            item.Enabled = true;
            item.Save();

            return RedirectToAction("ItemsList2", new { id = item.CatalogId });
        }


        // POST : /Catalogs/ItemDisable/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ItemDisable(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var item = new gCatalogItem(id);

            if (!item.Exist) return HttpNotFound();
            item.Enabled = false;
            item.Save();

            return RedirectToAction("ItemsList2", new { id = item.CatalogId });
        }


        // GET : /Catalogs/ItemDelete/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ItemDelete(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var item = new gCatalogItem(id);

            if (!item.Exist) return HttpNotFound();
            item.Deleted = true;
            item.Save();

            return RedirectToAction("ItemsList2", new { id = item.CatalogId });
        }


        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetDetails(long id)
        {
            var item = new gCatalog(id);
            return Json(new { id = item.Id, name = item.Name });
        }

        */

        // GET: /Catalogs/Registers

        public ActionResult Clasificacion(int idLiga)
        {
            ViewBag.LigaId = idLiga;
            //ViewBag.ItemId = item;

            return View(new cLigas().List(idLiga));
        }

        /*

        // POST : /Catalogs/RegisterEnable/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult RegisterEnable(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();
            var item = new gCatalogItemRegister(id);

            if (!item.Exist) return HttpNotFound();
            item.Enabled = true;

            result.success = item.Save();

            result.reload = result.success;
            if (!result.success) result.messaje = "No se ha podido completar la operación solicitada.";

            return Json(result);
        }


        // POST : /Catalogs/RegisterDisable/

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult RegisterDisable(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();
            var item = new gCatalogItemRegister(id);

            if (!item.Exist) return HttpNotFound();
            item.Enabled = false;

            result.success = item.Save();

            result.reload = result.success;
            if (!result.success) result.messaje = "No se ha podido completar la operación solicitada.";

            return Json(result);
        }


        // GET : /Catalogs/RegisterDelete/

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult RegisterDelete(long id)
        {
            if (!Request.IsAjaxRequest()) return HttpNotFound();

            var result = new Domain.Definitions.cJsonResultData();
            var item = new gCatalogItemRegister(id);

            if (!item.Exist) return HttpNotFound();
            item.Deleted = true;

            result.success = item.Save();

            result.reload = result.success;
            if (!result.success) result.messaje = "No se ha podido completar la operación solicitada.";

            return Json(result);
        }
        */

    }
}