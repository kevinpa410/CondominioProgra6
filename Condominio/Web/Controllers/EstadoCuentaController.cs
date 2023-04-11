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
                    TempData["Message"] = "No existe el Estado de Cuenta solicitado";
                    TempData["Redirect"] = "EstadoCuenta";
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

        // GET: EstadoCuenta/Edit/5
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
                    TempData["Message"] = "No existe el Plane de Cobro solicitado";
                    TempData["Redirect"] = "PlanesCobro";
                    TempData["Redirect-Action"] = "Index";
                    // Redireccion a la captura del Error
                    return RedirectToAction("Default", "Error");
                }

                //Listados//////////////////////////////
                ViewBag.IDPlanesCobro = listaPlanesCobro(estadoCuenta.ID);
                //Listados//////////////////////////////

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

        private SelectList listaPlanesCobro(int idUsuario = 0)
        {
            IServicesUsuario _ServicesUsuario = new ServicesUsuario();
            IEnumerable<Usuario> lista = _ServicesUsuario.GetUsuarios();
            return new SelectList(lista, "ID", "Total", idUsuario);
        }

    }
}
