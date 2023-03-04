using ApplicationCore.Services;
using Infraestructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PlanesCobroController : Controller
    {
        // GET: PlanesCobro
        public ActionResult Index()
        {
            IEnumerable<PlanesCobro> lista = null;
            try
            {
                IServicesPlanesCobro _ServicePlanesCobro = new ServicesPlanesCobro();
                lista = _ServicePlanesCobro.GetPlanesCobro();


                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: PlanesCobro/Details/5
        public ActionResult Details(int? id)
        {
            ServicesPlanesCobro _ServicePlanesCobro = new ServicesPlanesCobro();
            PlanesCobro planesCobro = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                planesCobro = _ServicePlanesCobro.GetPlanesCobroByID(Convert.ToInt32(id));
                if (planesCobro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(planesCobro);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: PlanesCobro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanesCobro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanesCobro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanesCobro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanesCobro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanesCobro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
