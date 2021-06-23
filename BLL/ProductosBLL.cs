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
    public class ProductosBLL
    {
        public static bool Guardar(Productos suplidor)
        {
            if (!Existe(suplidor.ProductoId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        private static bool Existe(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Productos.Any(x => x.ProductoId == id);
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

        private static bool Insertar(Productos producto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Add(producto);
                paso = (contexto.SaveChanges() > 0);
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

        private static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
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
            bool Eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var suplidor = Buscar(id);

                contexto.Entry(suplidor).State = EntityState.Deleted;
                Eliminado = (contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto;

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return producto;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> producto)
        {
            List<Productos> Lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Productos.Where(producto).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
