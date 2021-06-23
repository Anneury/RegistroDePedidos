using Microsoft.EntityFrameworkCore;
using RegistroDePedidos.DAL;
using RegistroDePedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroDePedidos.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(e => e.OrdenId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete from OrdenesDetalle where OrdenId = {ordenes.OrdenId}");

                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var ordenes = contexto.Ordenes.Find(id);
                if (ordenes != null)
                {
                    contexto.Entry(ordenes).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes ordenes;

            try
            {
                ordenes = contexto.Ordenes.Where(e => e.OrdenId == id).Include(e => e.Detalle).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Ordenes> lista = new List<Ordenes>();

            try
            {
                lista = contexto.Ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
