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
                    lista = ctx.PlanesCobro.
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
                        .Include("EstadoCuenta").
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

        public PlanesCobro Save(PlanesCobro planesCobro, string[] selectedRubroCobro) 
        {
            int retorno = 0;
            PlanesCobro oPlanesCobro = null;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oPlanesCobro = GetPlanesCobroByID((int)planesCobro.ID);
                IRepositoryRubroCobros _RepositoryRubroCobros = new RepositoryRubroCobros();

                if (oPlanesCobro == null)
                {

                    //Insertar
                    //Logica para agregar las categorias al libro
                    if (selectedRubroCobro != null)
                    {

                        planesCobro.RubroCobro = new List<RubroCobro>();
                        foreach (var rubroCobro in selectedRubroCobro)
                        {
                            var RubroCobroToAdd = _RepositoryRubroCobros.GetRubroCobroByID(int.Parse(rubroCobro));
                            ctx.RubroCobro.Attach(RubroCobroToAdd); //sin esto, EF intentará crear una categoría
                            planesCobro.RubroCobro.Add(RubroCobroToAdd);// asociar a la categoría existente con el libro


                        }
                    }
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

                    //Logica para actualizar Categorias
                    var selectedRubroCobroID = new HashSet<string>(selectedRubroCobro);
                    if (selectedRubroCobro != null)
                    {
                        ctx.Entry(planesCobro).Collection(p => p.RubroCobro).Load();
                        var newCategoriaForLibro = ctx.RubroCobro
                         .Where(x => selectedRubroCobroID.Contains(x.ID.ToString())).ToList();
                        planesCobro.RubroCobro = newCategoriaForLibro;

                        ctx.Entry(planesCobro).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }
            }

            if (retorno >= 0)
                oPlanesCobro = GetPlanesCobroByID((int)planesCobro.ID);

            return oPlanesCobro;
        }
    }
}
