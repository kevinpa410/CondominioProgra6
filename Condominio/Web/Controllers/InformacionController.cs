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
    public class InformacionController : Controller
    {
        // GET: Informacion
        public ActionResult Index()
        {
            IEnumerable<Informacion> lista = null;
            try
            {
                IServicesInformacion _ServiceInformacion = new ServicesInformacion();
                lista = _ServiceInformacion.GetInformacion();
                ViewBag.title = "Lista Libros";
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

        // GET: Informacion/Details/5
        public ActionResult Details(int? id)
        {
            ServicesInformacion _ServiceInformacion = new ServicesInformacion();
            Informacion informacion = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                informacion = _ServiceInformacion.GetInformacionByID(Convert.ToInt32(id));
                if (informacion == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(informacion);
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

        // GET: Informacion/Create
        public ActionResult Create()
        {
            ViewBag.IDTipoInformacion = listTipoInformacion();
            return View();
        }

        // GET: Informacion/Edit/5
        public ActionResult Edit(int? id)
        {
            ServicesInformacion _ServiceInformacion = new ServicesInformacion();
            Informacion informacion = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                informacion = _ServiceInformacion.GetInformacionByID(Convert.ToInt32(id));
                if (informacion == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(informacion);
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

        public ActionResult Save(Informacion informacion, HttpPostedFileBase ImageFile, string[] selectedCategorias)
        {
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesInformacion _ServicesInformacion = new ServicesInformacion();
            try
            {
                //Insertar la imagen
                if (informacion.Imagen == null)
                {
                    if (ImageFile != null)
                    {
                        ImageFile.InputStream.CopyTo(target);
                        informacion.Imagen = target.ToArray();
                        ModelState.Remove("Imagen");
                    }
                }
                if (ModelState.IsValid)
                {
                    Informacion oInformacion = _ServicesInformacion.Save(informacion);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDTipoInformacion = listTipoInformacion(Convert.ToInt32(informacion.IDTipoInformacion));
                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (informacion.IDTipoInformacion > 0)
                    {
                        return (ActionResult)View("Edit", informacion);
                    }
                    else
                    {
                        return View("Create", informacion);
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

        private SelectList listTipoInformacion(int idAutor = 0)
        {
            IServicesTipoInformacion _ServicesTipoInformacion = new ServicesTipoInformacion();
            IEnumerable<TipoInformacion> lista = _ServicesTipoInformacion.GetTipoInformacion();
            return new SelectList(lista, "ID", "Descripcion", idAutor);
        }

    }
}
