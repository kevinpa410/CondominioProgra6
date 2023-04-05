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
    public class RepositoryReservacion : IRepositoryReservacion
    {
        public IEnumerable<Reservaciones> GetReservaciones()
        {
            IEnumerable<Reservaciones> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.Reservaciones.
                        Include("Usuario").
                        Include("AreaComunal").
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

        public Reservaciones GetReservacionesByID(int id)
        {
            Reservaciones oReservaciones = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libro por ID incluyendo el autor y todas sus categorías
                    oReservaciones = ctx.Reservaciones.
                        Where(l => l.ID == id).
                        Include("Usuario").
                        Include("AreaComunal").
                        FirstOrDefault();

                }
                return oReservaciones;
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

        public Reservaciones Save(Reservaciones reservaciones)
        {
            int retorno = 0;
            Reservaciones oReservaciones = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oReservaciones = GetReservacionesByID((int)reservaciones.ID);

                if (oReservaciones == null)
                {


                    //Insertar Libro
                    ctx.Reservaciones.Add(reservaciones);
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
                    ctx.Reservaciones.Add(reservaciones);
                    ctx.Entry(reservaciones).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }

            if (retorno >= 0)
                oReservaciones = GetReservacionesByID((int)reservaciones.ID);

            return oReservaciones;
        }
    }
}
