    using ApplicationCore.Services;
using Infraestructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
            var usuario = (Infrastructure.Models.Usuario)Session["User"];

            IEnumerable<EstadoCuenta> lista = null;
            try
            {
                IServicesEstadoCuenta _ServicesEstadoCuenta = new ServicesEstadoCuenta();
                lista = _ServicesEstadoCuenta.GetEstadosCuentaByUsuario(Convert.ToInt32(usuario.ID));
                


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

        public ActionResult IndexAdmin()
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

        public ActionResult Create()
        {
            ViewBag.IDPlanCobro = listaPlanesCobro();
            ViewBag.IDUsuario = listaUsuarios();

            return View();
        }
        public ActionResult Details(int? ID)
        {
            ServicesEstadoCuenta _ServicesEstadoCuenta = new ServicesEstadoCuenta();
            EstadoCuenta estadoCuenta = null;

            
            try
            {
                // Si va null
                if (ID == null)
                {
                    return RedirectToAction("Index");
                }

                estadoCuenta = _ServicesEstadoCuenta.GetEstadoCuentaByID(Convert.ToInt32(ID));
                var HistorialPagos = _ServicesEstadoCuenta.GetEstadoCuentaByHistorialPagos(Convert.ToInt32(ID));
                var PagosPendientes = _ServicesEstadoCuenta.GetEstadoCuentaByPagosPendientes(Convert.ToInt32(ID));


                if (estadoCuenta == null)
                {
                    TempData["Message"] = "No existe el Estado de Cuenta solicitado";
                    TempData["Redirect"] = "EstadoCuenta";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                ViewBag.HistorialPagos = HistorialPagos;
                ViewBag.PagosPendientes = PagosPendientes;
                

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
        //GET: EstadoCuenta/Edit/5
        [HttpGet]
        public ActionResult EditAdmin(int? id)
        {
            ServicesEstadoCuenta _ServiceEstadoCuenta = new ServicesEstadoCuenta();
            ServicesResidencias _ServicesResidencias = new ServicesResidencias();
            EstadoCuenta estadoCuenta = null;      
            Residencias residencias = null;


            try
            {
                if (id == null)
                {
                    return RedirectToAction("Indexadmin", "Ususario");
                }

                //Get by Usuario ID//////////////////////////////
                estadoCuenta = _ServiceEstadoCuenta.GetEstadoCuentaByUsuario(Convert.ToInt32(id));
                //Get by Usuario ID//////////////////////////////
                if (estadoCuenta == null)
                {
                    residencias = _ServicesResidencias.GetResidenciasByUsuario(Convert.ToInt32(id));
                    if (residencias == null)
                    {
                        TempData["Message"] = "Este Usuario no tiene una Residencia";
                        TempData["Redirect"] = "Residencias";
                        TempData["Redirect-Action"] = "IndexAdmin";
                        // Redireccion a la captura del Error
                        return RedirectToAction("Default", "Error");
                    }

                    estadoCuenta = new EstadoCuenta();
                    estadoCuenta.IDPlanCobro = 0;
                    estadoCuenta.IDUsuario = id;
                    estadoCuenta.IDResidencia = residencias.ID;
                    estadoCuenta.IDEstado = null;
                    estadoCuenta.Mes = null;
                    ViewBag.IDPlanCobro = listaPlanesCobro();
                    return View(estadoCuenta);
                }

                //Listados//////////////////////////////
                ViewBag.IDPlanCobro = listaPlanesCobro(estadoCuenta.ID);
                //Listados//////////////////////////////

                return View(estadoCuenta);
            }
            catch (DbEntityValidationException ex)
            {
                //Loop through the validation errors and log them
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        string errorMessage = $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                        // log the error message or handle it as appropriate
                    }
                }

                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Libro";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        //GET: EstadoCuenta/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ServicesEstadoCuenta _ServiceEstadoCuenta = new ServicesEstadoCuenta();
            EstadoCuenta estadoCuenta = null;            

            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                //Get by Usuario ID//////////////////////////////
                estadoCuenta = _ServiceEstadoCuenta.GetEstadoCuentaByUsuario(Convert.ToInt32(id));
                //Get by Usuario ID//////////////////////////////
                if (estadoCuenta == null)
                {
                    TempData["Message"] = "No existe el Plan de Cobro solicitado";
                    TempData["Redirect"] = "EstadoCuenta";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                //Listados//////////////////////////////
                ViewBag.IDPlanCobro = listaPlanesCobro(estadoCuenta.ID);
                //Listados//////////////////////////////

                return View(estadoCuenta);
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
                TempData["Redirect"] = "EstadoCuenta";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
        private SelectList listaPlanesCobro(int idPlanesCobro = 0)
        {
            IServicesPlanesCobro _ServicesPlanesCobro = new ServicesPlanesCobro();
            IEnumerable<PlanesCobro> lista = _ServicesPlanesCobro.GetPlanesCobro();
            return new SelectList(lista, "ID", "Descripcion", idPlanesCobro);
        }

        private SelectList listaUsuarios(int idUsuarios = 0)
        {
            IServicesUsuario _ServicesUsuario  = new ServicesUsuario();
            IEnumerable<Usuario> lista = _ServicesUsuario.GetUsuarios();
            return new SelectList(lista, "ID", "nombre", idUsuarios);
        }

        public ActionResult Save(EstadoCuenta estadoCuenta)
        {
            MemoryStream target = new MemoryStream();

            IServicesEstadoCuenta _ServicesEstadoCuenta = new ServicesEstadoCuenta();
            try
            {
                if (ModelState.IsValid)
                {
                    if (estadoCuenta.IDEstado == null)
                    {
                        estadoCuenta.IDEstado = 1;
                    }
                    else
                    {
                        estadoCuenta.IDEstado = 2;
                    }
                    EstadoCuenta oEstadoCuenta = _ServicesEstadoCuenta.Save(estadoCuenta);
                }                                    
                else
                {

                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDEstado = listaPlanesCobro(Convert.ToInt32(estadoCuenta.IDEstado));
                    ViewBag.IDEstado = listaUsuarios(Convert.ToInt32(estadoCuenta.IDUsuario));


                    if (estadoCuenta.ID > 0)
                    {
                        return (ActionResult)View("Edit", estadoCuenta);
                    }
                    else
                    {

                        return View("Create", estadoCuenta);
                    }
                }
                return RedirectToAction("IndexAdmin");
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
                TempData["Redirect"] = "EstadoCuenta";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        //public ActionResult SaveAdmin(EstadoCuenta estadoCuenta)
        //{
        //    //Gestión de archivos
        //    MemoryStream target = new MemoryStream();
        //    //Servicio Libro
        //    IServicesEstadoCuenta _ServicesEstadoCuenta = new ServicesEstadoCuenta();
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                estadoCuenta.IDEstado = 2;
        //            }
        //            EstadoCuenta oEstadoCuenta = _ServicesEstadoCuenta.Save(estadoCuenta);
        //        }
        //        else
        //        {
        //            // Valida Errores si Javascript está deshabilitado
        //            Utils.Util.ValidateErrors(this);
        //            ViewBag.IDEstado = listaPlanesCobro(Convert.ToInt32(estadoCuenta.IDEstado));
        //            //Cargar la vista crear o actualizar
        //            //Lógica para cargar vista correspondiente
        //            if (estadoCuenta.ID > 0)
        //            {
        //                return (ActionResult)View("Edit", estadoCuenta);
        //            }
        //            else
        //            {

        //                return View("Create", estadoCuenta);
        //            }
        //        }

        //        return RedirectToAction("IndexAdmin","Ususario");
        //    }
        //    catch (DbEntityValidationException ex)
        //    {

        //        ////Loop through the validation errors and log them
        //        //foreach (var error in ex.EntityValidationErrors)
        //        //{
        //        //    foreach (var validationError in error.ValidationErrors)
        //        //    {
        //        //        string errorMessage = $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
        //        //        // log the error message or handle it as appropriate
        //        //    }
        //        //}

        //        // Salvar el error en un archivo 
        //        Log.Error(ex, MethodBase.GetCurrentMethod());
        //        TempData["Message"] = "Error al procesar los datos! " + ex.Message;
        //        TempData["Redirect"] = "EstadoCuenta";
        //        TempData["Redirect-Action"] = "IndexAdmin";
        //        // Redireccion a la captura del Error
        //        return RedirectToAction("Default", "Error");
        //    }
        //}
    }
}
