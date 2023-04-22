using ApplicationCore.Services;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web.Utils;

namespace Web.Controllers
{
    public class ReservacionController : Controller
    {
        
        // GET: Reservacion
        public ActionResult Index()
        {
            var usuario = (Infrastructure.Models.Usuario)Session["User"];

            IEnumerable<Reservaciones> lista = null;
            try
            {
                IServicesReservacion _ServiceReservacion = new ServicesReservacion();
                lista = _ServiceReservacion.GetReservacionesByUsuario(Convert.ToInt32(usuario.ID));
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
            return View(lista);
        }

        public ActionResult IndexAdmin()
        {
            IEnumerable<Reservaciones> lista = null;
            try
            {
                IServicesReservacion _ServicesReservacion = new ServicesReservacion();
                lista = _ServicesReservacion.GetReservaciones();

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

        // GET: Reservacion/Details/5
        public ActionResult Details(int? id)
        {
            ServicesReservacion _ServicesReservacion = new ServicesReservacion();
            Reservaciones reservaciones = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                reservaciones = _ServicesReservacion.GetReservacionesByID(Convert.ToInt32(id));
                if (reservaciones == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                return View(reservaciones);
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

        // GET: Reservacion/Create
        public ActionResult Create()
        {
            ViewBag.IDAreaComunal = listaAreaComunal();
            ViewBag.IDUsuario = listaUsuarios();
            ViewBag.IDEstadoReservaciones = listaEstadoReservaciones();
            return View();
        }

        // GET: Reservaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            ServicesReservacion _ServicesReservacion = new ServicesReservacion();
            Reservaciones reservaciones = null;
            var usuario = (Infrastructure.Models.Usuario)Session["User"];

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                reservaciones = _ServicesReservacion.GetReservacionesByID(Convert.ToInt32(id));
                reservaciones.IDUsuario = usuario.ID;
                if (reservaciones == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    TempData["Redirect"] = "Libro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                // Set IDEstadoReservaciones to the existing value in the database
                reservaciones.IDEstadoReservaciones = _ServicesReservacion.GetReservacionesByID(Convert.ToInt32(id)).IDEstadoReservaciones;


                //Listados///////////////////////////
                ViewBag.IDAreaComunal = listaAreaComunal(Convert.ToInt32(reservaciones.IDAreaComunal));
                //Listados//////////////////////////////


                return View(reservaciones);
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


        public ActionResult EditAdmin(int? id)
        {
            ServicesReservacion _ServicesReservacion = new ServicesReservacion();
            Reservaciones reservaciones = null;

            try
            {
                // Si va null
                if (id == null)
                {
                    return RedirectToAction("IndexAdmin");
                }

                reservaciones = _ServicesReservacion.GetReservacionesByID(Convert.ToInt32(id));
                if (reservaciones == null)
                {
                    TempData["Message"] = "No existe la Reservacion solicitada";
                    TempData["Redirect"] = "Reservaciones";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }
                //Listados
                ViewBag.IDAreaComunal = listaAreaComunal(Convert.ToInt32(reservaciones.IDAreaComunal));
                ViewBag.IDUsuario = listaUsuarios(Convert.ToInt32(reservaciones.IDUsuario));
                ViewBag.IDEstadoReservaciones = listaEstadoReservaciones(Convert.ToInt32(reservaciones.IDEstadoReservaciones));
                return View(reservaciones);
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Reservaciones";
                TempData["Redirect-Action"] = "IndexAdmin";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult Save(Reservaciones reservaciones)
        {
            var usuario = (Infrastructure.Models.Usuario)Session["User"];
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesReservacion _ServicesReservaciones = new ServicesReservacion();
            IEnumerable<Reservaciones> lista = _ServicesReservaciones.GetReservaciones();

            try
            {
                if (ModelState.IsValid)
                {
                    if (reservaciones.IDEstadoReservaciones == null)
                    {
                        reservaciones.IDEstadoReservaciones = 1;                      
                    }

                    //if (!lista.Any(r => r.Fecha != reservaciones.Fecha || r.IDAreaComunal != reservaciones.IDAreaComunal))
                    //{
                        reservaciones.IDUsuario = usuario.ID;
                        Reservaciones oReservaciones = _ServicesReservaciones.Save(reservaciones);
                        Log.Warn($"No se pudo guardar la Reservacion");
                        ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Reservacion", "La reservacion Se guardo con Exito", Util.SweetAlertMessageType.error);

                    //}
                    //else
                    //{

                    //    Log.Warn($"No se pudo guardar la Reservacion");
                    //    ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Reservacion", "La reservacion ya existe", Util.SweetAlertMessageType.error);
                    
                    //}
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDAreaComunal = listaAreaComunal(Convert.ToInt32(reservaciones.IDAreaComunal));

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (reservaciones.ID > 0)
                    {
                        return (ActionResult)View("Edit", reservaciones);
                    }
                    else
                    {
                        return View("Create", reservaciones);
                    }
                }


                Log.Warn($"No se pudo guardar la Reservacion");
                string mensaje = "La reservacion ya existe";
                string tipoMensaje = "error";
                string tituloMensaje = "Reservacion";
                string script = $"Swal.fire('{mensaje}', '{tituloMensaje}', '{tipoMensaje}');";
                TempData["NotificationScript"] = script;
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
                TempData["Redirect"] = "Reservacion";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult SaveAdmin(Reservaciones reservaciones)
        {
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesReservacion _ServicesReservaciones = new ServicesReservacion();

            try
            {
                if (ModelState.IsValid)
                {
                        Reservaciones oReservaciones = _ServicesReservaciones.Save(reservaciones);
                        Log.Warn($"No se pudo guardar la Reservacion");
                        ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Reservacion", "La reservacion Se guardo con Exito", Util.SweetAlertMessageType.error);
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDAreaComunal = listaAreaComunal(Convert.ToInt32(reservaciones.IDAreaComunal));

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (reservaciones.ID > 0)
                    {
                        return (ActionResult)View("Edit", reservaciones);
                    }
                    else
                    {
                        return View("Create", reservaciones);
                    }
                }

                Log.Warn($"No se pudo guardar la Reservacion");
                string mensaje = "La reservacion ya existe";
                string tipoMensaje = "error";
                string tituloMensaje = "Reservacion";
                string script = $"Swal.fire('{mensaje}', '{tituloMensaje}', '{tipoMensaje}');";
                TempData["NotificationScript"] = script;
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
                TempData["Redirect"] = "Reservacion";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }

        }

        private SelectList listaAreaComunal(int IDArea = 0)
        {
            IServiceAreaComunal _ServiceAreaComunal = new ServiceAreaComunal();
            IEnumerable<AreaComunal> lista = _ServiceAreaComunal.GetAreaComunal();
            return new SelectList(lista, "ID", "Descripcion", IDArea);
        }

        private SelectList listaUsuarios(int IDUsuario = 0)
        {
            IServicesUsuario _ServicesUsuario = new ServicesUsuario();
            IEnumerable<Usuario> lista = _ServicesUsuario.GetUsuarios();
            return new SelectList(lista, "ID", "nombre", IDUsuario);
        }

        private SelectList listaEstadoReservaciones(int IDEstado = 0)
        {
            IServicesEstadoReservaciones _ServicesEstadoReservaciones = new ServicesEstadoReservaciones();
            IEnumerable<EstadoReservaciones> lista = _ServicesEstadoReservaciones.GetEstadoReservaciones();
            return new SelectList(lista, "ID", "Descripcion", IDEstado);
        }

    }
}
