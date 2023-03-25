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
using System.Web.Security;
using Web.Security;
using Web.Utils;

namespace Web.Controllers
{
    public class UsusarioController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            IServicesUsuario _ServicesUsuario = new ServicesUsuario();
            Usuario oUsuario = null;
            try
            {
                ModelState.Remove("nombre");
                ModelState.Remove("apellido");
                ModelState.Remove("IDRol");
                //Verificar las credenciales
                if (ModelState.IsValid)
                {
                    oUsuario = _ServicesUsuario.GetUsuario(usuario.correo, usuario.contrasenna);
                    if (oUsuario != null)
                    {
                        Session["User"] = oUsuario;
                        Log.Info($"Inicio sesion: {usuario.correo}");
                        TempData["mensaje"] = Util.SweetAlertHelper.Mensaje("Login",
                            "Usuario autenticado", Util.SweetAlertMessageType.success
                            );
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Log.Warn($"Intento de inicio: {usuario.correo}");
                        ViewBag.NotificationMessage = Util.SweetAlertHelper.Mensaje("Login",
                            "Usuario no válido", Util.SweetAlertMessageType.error
                            );
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                //Loop through the validation errors and log them
                //foreach (var error in ex.EntityValidationErrors)
                //{
                //    foreach (var validationError in error.ValidationErrors)
                //    {
                //        string errorMessage = $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                //        // log the error message or handle it as appropriate
                //    }
                //}

                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
            return View("Index");
        }
        public ActionResult UnAuthorized()
        {
            ViewBag.Message = "No autorizado";
            if (Session["User"] != null)
            {
                Usuario usuario = Session["User"] as Usuario;
                Log.Warn($"No autorizado {usuario.correo}");
            }
            return View();
        }
        public ActionResult Logout()
        {
            try
            {
                //Eliminar variable de sesion
                Session["User"] = null;
                Session.Remove("User");

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }

        //[HttpGet]
        //[CustomAuthorize((int)Rols.Administrador)]
        public ActionResult Create()
        {
            ViewBag.IDRol = listRol();
            return View();
        }
        private SelectList listRol(int IDRol = 0)
        {
            IServicesRol _ServiceRol = new ServicesRol();
            IEnumerable<Rol> lista = _ServiceRol.GetRol();
            return new SelectList(lista, "ID", "descripcion", IDRol);
        }

        public ActionResult Save(Usuario usuario)
        {
            //Gestión de archivos
            MemoryStream target = new MemoryStream();
            //Servicio Libro
            IServicesUsuario _ServicesUsuario = new ServicesUsuario();
            try
            {
                
                if (ModelState.IsValid)
                {
                    if (usuario.activo == null)
                    {
                        usuario.activo = 1;
                    }                    
                    Usuario oUsuario = _ServicesUsuario.Save(usuario);                    
                }
                else
                {
                    // Valida Errores si Javascript está deshabilitado
                    Utils.Util.ValidateErrors(this);
                    ViewBag.IDRol = listRol(Convert.ToInt32(usuario.IDRol));

                    //Cargar la vista crear o actualizar
                    //Lógica para cargar vista correspondiente
                    if (usuario.ID != 0)
                    {
                        return View("Create", usuario);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {

                // Loop through the validation errors and log them
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
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "Index";

                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }
        }
    }
}
