using ApplicationCore.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Security;
using Web.Utils;

namespace Web.Controllers
{
    public class IncidenciasController : Controller
    {
        // GET: Incidencias
        public ActionResult Index()
        {
            IEnumerable<Incidencias> lista = null;
            try
            {
                IServicesIncidencias _ServiceIncidencias = new ServicesIncidencias();
                lista = _ServiceIncidencias.GetIncidencias();


                return View(lista);
            }
            catch (Exception ex)
            {
                Utils.Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: Incidencias/Details/5
        public ActionResult Details(int? id)
        {
            ServicesIncidencias _ServicesIncidencias = new ServicesIncidencias();
            Incidencias incidencias = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                incidencias = _ServicesIncidencias.GetIncidenciasByID(Convert.ToInt32(id));
                if (incidencias == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(incidencias);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Utils.Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: Incidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        private SelectList listEstadoIncidencias(int? IDEstadoIncidencias = 0)
        {
            IServicesEstadoIncidencias _EstadoIncidencias = new ServicesEstadoIncidencias();
            IEnumerable<EstadoIncidencia> lista = _EstadoIncidencias.GetEstadoIncidencia();
            return new SelectList(lista, "ID", "Descripcion", IDEstadoIncidencias);
        }

        // GET: Incidencias/Edit/5
        [HttpGet]
        [CustomAuthorize((int)Rols.Administrador)]
        public ActionResult Edit(int? id)
        {
            ServicesIncidencias _ServicesIncidencias = new ServicesIncidencias();
            Incidencias incidencias = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                incidencias = _ServicesIncidencias.GetIncidenciasByID(Convert.ToInt32(id));
                if (incidencias == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Listados
                ViewBag.IDEstado = listEstadoIncidencias(incidencias.IDEstado);
                return View(incidencias);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult Save(Incidencias incidencias)
        {

            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesIncidencias _ServicesIncidencias = new ServicesIncidencias();
            try
            {

                if (ModelState.IsValid)
                {
                    if (incidencias.IDEstado == null)
                    {
                        incidencias.IDEstado = 1;
                    }
                    Incidencias oIncidencias = _ServicesIncidencias.Save(incidencias);
                }
                else
                {

                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDEstado = listEstadoIncidencias(incidencias.IDEstado);
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (incidencias.ID > 0)
                    {
                        return (ActionResult)View("Edit", incidencias);
                    }
                    else
                    {

                        return View("Create", incidencias);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {

                ////Loop through the validation errors and log them
                //foreach (var error in ex.EntityValidationErrors)
                //{
                //    foreach (var validationError in error.ValidationErrors)
                //    {
                //        string errorMessage = $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                //        // log the error message or handle it as appropriate
                //    }
                //}

                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

    }
}
