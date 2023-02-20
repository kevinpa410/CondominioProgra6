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
    public class ResidenciasController : Controller
    {
        // GET: Residencias
        public ActionResult Index()
        {
            return View();
        }
        // GET: Residencias
        public ActionResult IndexAdmin()
        {
            IEnumerable<Residencias> lista = null;
            try
            {
                IServicesResidencias _ServiceResidencias = new ServicesResidencias();
                lista = _ServiceResidencias.GetResidencias();


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

        // GET: Residencias/Details/5
        public ActionResult Details(int id)
        {
            ServicesResidencias _ServiceResidencias = new ServicesResidencias();
            Residencias residencias = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                residencias = _ServiceResidencias.GetResidenciasByID(Convert.ToInt32(id));
                if (residencias == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(residencias);
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

        // GET: Residencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Residencias/Create
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

        // GET: Residencias/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Residencias/Edit/5
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
    }
}
