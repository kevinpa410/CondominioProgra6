using ApplicationCore.Services;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class RubroCobroController : Controller
    {
        // GET: RubroCobro
        public ActionResult Index()
        {
            IEnumerable<RubroCobro> lista = null;
            try
            {
                IServicesRubroCobro _ServicesRubroCobro = new ServicesRubroCobro();
                lista = _ServicesRubroCobro.GetRubroCobros();


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
        // GET: RubroCobro/Details/5
        public ActionResult Details(int? id)
        {
            IServicesRubroCobro _ServicesRubroCobro = new ServicesRubroCobro();
            RubroCobro rubroCobro = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                rubroCobro = _ServicesRubroCobro.GetRubroCobroByID(Convert.ToInt32(id));
                if (rubroCobro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(rubroCobro);
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
        // GET: RubroCobro/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(RubroCobro rubroCobro)
        {
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesRubroCobro _ServicesRubroCobro = new ServicesRubroCobro();
            try
            {

                if (ModelState.IsValid)
                {
                    RubroCobro orubroCobro = _ServicesRubroCobro.Save(rubroCobro);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Util.ValidateErrors(this);

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (rubroCobro.ID > 0)
                    {
                        return (ActionResult)View("Edit", rubroCobro);
                    }
                    else
                    {
                        return View("Create", rubroCobro);
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
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        // GET: RubroCobro/Edit/5
        public ActionResult Edit(int? id)
        {
            ServicesRubroCobro _ServicesRubroCobro = new ServicesRubroCobro();
            RubroCobro rubroCobro = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                rubroCobro = _ServicesRubroCobro.GetRubroCobroByID(Convert.ToInt32(id));
                if (rubroCobro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Listados
                return View(rubroCobro);
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

    }
}
