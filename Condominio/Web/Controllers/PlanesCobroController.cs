using ApplicationCore.Services;
using Infraestructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web.Utils;
using Log = Web.Utils.Log;

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
            ViewBag.IDRubroCobro = listaRubroCobro();
            return View();
        }

        private MultiSelectList listaRubroCobro(ICollection<RubroCobro> rubroCobro = null)
        {
            IServicesRubroCobro _ServicesRubroCobro = new ServicesRubroCobro();
            IEnumerable<RubroCobro> lista = _ServicesRubroCobro.GetRubroCobros();
            //Seleccionar categorias
            int[] listaRubroCobroSelect = null;
            if (rubroCobro != null)
            {
                listaRubroCobroSelect = rubroCobro.Select(c => c.ID).ToArray();
            }

            return new MultiSelectList(lista, "ID", "Descripcion", listaRubroCobroSelect);
        }

        // GET: PlanesCobro/Edit/5
        public ActionResult Edit(int? id)
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
                    TempData["Message"] = "No existe el Planes de Cobro solicitado";
                    TempData["Redirect"] = "PlanesCobro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                //Listados///////////////////////////
                ViewBag.IDRubroCobro = listaRubroCobro(planesCobro.RubroCobro);
                //Listados//////////////////////////////

                return View(planesCobro);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "PlanesCobro";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Save(PlanesCobro planesCobro, string[] selectedRubroCobro)
        {
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesPlanesCobro _ServicePlanesCobro = new ServicesPlanesCobro();
            try
            {
                
                if (ModelState.IsValid)
                {
                    PlanesCobro oPlanesCobro = _ServicePlanesCobro.Save(planesCobro, selectedRubroCobro);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDRubroCobro = listaRubroCobro(planesCobro.RubroCobro);

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (planesCobro.ID > 0)
                    {
                        return (ActionResult)View("Edit", planesCobro);
                    }
                    else
                    {
                        return View("Create", planesCobro);
                    }
                }

                return RedirectToAction("Index");
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

    }
}

