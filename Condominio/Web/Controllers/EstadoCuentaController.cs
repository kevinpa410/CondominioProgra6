using ApplicationCore.Services;
using Infraestructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class EstadoCuentaController : Controller
    {
        // GET: EstadoCuenta
        public ActionResult Index()
        {
            IEnumerable<EstadoCuenta> lista = null;
            try
            {
                IServicesEstadoCuenta _ServicesEstadoCuenta = new ServicesEstadoCuenta();
                lista = _ServicesEstadoCuenta.GetEstadoCuenta();


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

        //GET: EstadoCuenta/Details/5
        public ActionResult Details(int? ID)
        {
            ServicesEstadoCuenta _ServicesEstadoCuenta = new ServicesEstadoCuenta();
            EstadoCuenta estadoCuenta = null;

            IServicesEstadoCuenta _ServiceEstadoCuenta = new ServicesEstadoCuenta();
            ViewBag.DeudasVigentes = _ServiceEstadoCuenta.GetEstadoCuentaByEstado(Convert.ToInt32(ID), 1);
            ViewBag.HistorialPagos = _ServiceEstadoCuenta.GetEstadoCuentaByEstado(Convert.ToInt32(ID), 2);

            try
            {
                // Si va null
                if (ID == null)
                {
                    return RedirectToAction("Index");
                }

                estadoCuenta = _ServicesEstadoCuenta.GetEstadoCuentaByID(Convert.ToInt32(ID));

                if (estadoCuenta == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(estadoCuenta);
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

        // GET: EstadoCuenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCuenta/Create
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

        // GET: EstadoCuenta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadoCuenta/Edit/5
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

        // GET: EstadoCuenta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoCuenta/Delete/5
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
