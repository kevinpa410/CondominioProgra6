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
    public class RepositoryPlanCobro : IRepositoryPlanCobro
    {
        public IEnumerable<PlanesCobro> GetPlanesCobro()
        {
            IEnumerable<PlanesCobro> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.PlanesCobro
                        .Include("EstadoPlanesCobro").
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

        public PlanesCobro GetPlanesCobroByID(int id)
        {
            PlanesCobro oPlanesCobro = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libro por ID incluyendo el autor y todas sus categorías
                    oPlanesCobro = ctx.PlanesCobro.
                        Where(l => l.ID == id)
                        .Include("RubroCobro")
                        .Include("EstadoCuenta")
                        .Include("EstadoPlanesCobro").
                        FirstOrDefault();

                }
                return oPlanesCobro;
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

        public PlanesCobro Save(PlanesCobro planesCobro) //Review Code
        {
            int retorno = 0;
            PlanesCobro oPlanesCobro = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oPlanesCobro = GetPlanesCobroByID((int)planesCobro.ID);
                //IRepositoryResidencias _RepositoryCategoria = new RepositoryResidencias();

                if (oPlanesCobro == null)
                {


                    //Insertar Libro
                    ctx.PlanesCobro.Add(planesCobro);
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
                    ctx.PlanesCobro.Add(planesCobro);
                    ctx.Entry(planesCobro).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }

            if (retorno >= 0)
                oPlanesCobro = GetPlanesCobroByID((int)planesCobro.ID);

            return oPlanesCobro;
        }
    }
}
