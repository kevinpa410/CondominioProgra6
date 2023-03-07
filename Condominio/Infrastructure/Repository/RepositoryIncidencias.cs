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
    public class RepositoryIncidencias : IRepositoryIncidencias
    {
        public IEnumerable<Incidencias> GetIncidencias()
        {
            IEnumerable<Incidencias> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.Incidencias.
                        Include("EstadoIncidencia").
                        Include("Residencias").
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

        public Incidencias GetIncidenciasByID(int id)
        {
            Incidencias oIncidencias = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libro por ID incluyendo el autor y todas sus categorías
                    oIncidencias = ctx.Incidencias.
                        Where(l => l.ID == id).
                        Include("EstadoIncidencia").
                        Include("Residencias").
                        FirstOrDefault();

                }
                return oIncidencias;
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

        public Incidencias Save(Incidencias incidencias)
        {
            int retorno = 0;
            Incidencias oIncidencias = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oIncidencias = GetIncidenciasByID((int)incidencias.ID);

                if (oIncidencias == null)
                {


                    //Insertar Libro
                    ctx.Incidencias.Add(incidencias);
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
                    ctx.Incidencias.Add(incidencias);
                    ctx.Entry(incidencias).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }

            if (retorno >= 0)
                oIncidencias = GetIncidenciasByID((int)incidencias.ID);

            return oIncidencias;
        }
    }
}
