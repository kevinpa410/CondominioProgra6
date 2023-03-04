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
                Utils.Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        // GET: Residencias/Details/5
        public ActionResult Details(int? id)
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
                Utils.Log.Error(ex, MethodBase.GetCurrentMethod());
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
            ViewBag.IDEstado = listaEstadoResidencias();
            ViewBag.IDUsuario = listaUsuario();
            return View();
        }

        private SelectList listaEstadoResidencias(int IDEstado = 0)
        {
            IServicesEstadoResidencias _ServicesEstadoResidencias = new ServicesEstadoResidencias();
            IEnumerable<EstadoResidencias> lista = _ServicesEstadoResidencias.GetEstadoResidencias();
            return new SelectList(lista, "ID", "descripcion", IDEstado);
        }

        private SelectList listaUsuario(int idUsuario = 0)
        {
            IServicesUsuario _ServicesUsuario = new ServicesUsuario();
            IEnumerable<Usuario> lista = _ServicesUsuario.GetUsuarios();
            return new SelectList(lista, "ID", "nombre",idUsuario);
        }

        // POST: Residencias/Create
        [HttpPost]
        public ActionResult Save(Residencias residencias)
        {
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesResidencias _ServicesResidencias = new ServicesResidencias();
            try
            {
                
                if (ModelState.IsValid)
                {
                    Residencias oResidencias = _ServicesResidencias.Save(residencias);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Util.ValidateErrors(this);
                    ViewBag.IDEstadoResidencias = listaEstadoResidencias(Convert.ToInt32(residencias.IDEstado));
                    ViewBag.idUsuario = listaUsuario(residencias.IDUsuario);
                    

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (residencias.ID > 0)
                    {
                        return (ActionResult)View("Edit", residencias);
                    }
                    else
                    {
                        return View("Create", residencias);
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
