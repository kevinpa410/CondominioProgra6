using Infraestructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryEstadoCuenta : IRepositoryEstadoCuenta
    {
        public IEnumerable<EstadoCuenta> GetEstadoCuenta()
        {
            IEnumerable<EstadoCuenta> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.EstadoCuenta
                        .Include("PlanesCobro")
                        .Include("Residencias")
                        .Include("Usuario").
                        ToList();

                    //lista = ctx.Libro.Include(x=>x.Autor).ToList();

                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<EstadoCuenta> GetEstadoCuentaByEstado(int IDResidencia, int IDEstado)
        {
            IEnumerable<EstadoCuenta> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.EstadoCuenta.
                        Where(x => x.IDResidencia == IDResidencia && x.IDEstado == IDEstado)
                        .Include("PlanesCobro")
                        .Include("Estado_EstadoCuenta")
                        .Include("PlanesCobro.RubroCobro")
                        .Include("Residencias")
                        .Include("Usuario").
                        ToList();
                    
                }

                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<EstadoCuenta> GetEstadoCuentaByPagosPendientes(int IDUsuario)
        {
            IEnumerable<EstadoCuenta> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.EstadoCuenta.
                        Where(x => x.IDUsuario == IDUsuario && x.IDEstado == 1)
                        .Include("PlanesCobro")
                        .Include("Estado_EstadoCuenta")
                        .Include("PlanesCobro.RubroCobro")
                        .Include("Residencias")
                        .Include("Usuario").
                        ToList();

                }

                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<EstadoCuenta> GetEstadoCuentaByHistorialPagos(int IDUsuario)
        {
            IEnumerable<EstadoCuenta> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.EstadoCuenta.
                        Where(x => x.IDUsuario == IDUsuario && x.IDEstado == 2)
                        .Include("PlanesCobro")
                        .Include("Estado_EstadoCuenta")
                        .Include("PlanesCobro.RubroCobro")
                        .Include("Residencias")
                        .Include("Usuario").
                        ToList();

                }

                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public EstadoCuenta GetEstadoCuentaByID(int id)
        {
            EstadoCuenta oEstadoCuenta = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libro por ID incluyendo el autor y todas sus categorías
                    oEstadoCuenta = ctx.EstadoCuenta.
                        Where(l => l.ID == id)
                        .Include("PlanesCobro")
                        .Include("Residencias")
                        .Include("Usuario").
                        FirstOrDefault();

                }
                return oEstadoCuenta;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
        public EstadoCuenta GetEstadoCuentaByUsuario(int idusuario)
        {
            EstadoCuenta oEstadoCuenta = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libros por Autor
                    oEstadoCuenta = ctx.EstadoCuenta.
                        Where(l => l.IDUsuario == idusuario).
                         Include("PlanesCobro")
                        .Include("Residencias")
                        .Include("Usuario").FirstOrDefault();

                }
                return oEstadoCuenta;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
        public EstadoCuenta Save(EstadoCuenta estadoCuenta)
        {
            int retorno = 0;
            EstadoCuenta oEstadoCuenta = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oEstadoCuenta = GetEstadoCuentaByID((int)estadoCuenta.ID);

                if (oEstadoCuenta == null)
                {


                    //Insertar Libro
                    ctx.EstadoCuenta.Add(estadoCuenta);
                    //SaveChanges
                    //guarda todos los cambios realizados en el contexto de la base de datos.
                    retorno = ctx.SaveChanges();
                    //retorna número de filas afectadas
                }
                else
                {
                    //Registradas: 1,2,3
                    //Actualizar: 1,3,4

                    //Actualizar Libro
                    ctx.EstadoCuenta.Add(estadoCuenta);
                    ctx.Entry(estadoCuenta).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }

            if (retorno >= 0)
                oEstadoCuenta = GetEstadoCuentaByID((int)estadoCuenta.ID);

            return oEstadoCuenta;
        }

        public IEnumerable<EstadoCuenta> GetEstadosCuentaByUsuario(int idusuario)
        {
            IEnumerable<EstadoCuenta> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.EstadoCuenta.
                        Where(x => x.IDUsuario == idusuario)
                        .Include("PlanesCobro")
                        .Include("Estado_EstadoCuenta")
                        .Include("PlanesCobro.RubroCobro")
                        .Include("Residencias")
                        .Include("Usuario").
                        ToList();

                }

                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}
