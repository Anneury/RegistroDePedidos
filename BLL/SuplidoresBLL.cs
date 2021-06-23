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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            if (!Existe(suplidor.SuplidorId))
                return Insertar(suplidor);
            else
                return Modificar(suplidor);
        }

        private static bool Existe(int id)
        {
            bool Existencia = false;
            Contexto contexto = new Contexto();

            try
            {
                Existencia = contexto.Suplidores.Any(x => x.SuplidorId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Existencia;
        }

        private static bool Insertar(Suplidores suplidor)
        {
            bool Insertado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Suplidores.Add(suplidor);
                Insertado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Insertado;
        }

        private static bool Modificar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
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

        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;

            try
            {
                suplidor = contexto.Suplidores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidor;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidor)
        {
            List<Suplidores> Lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Suplidores.Where(suplidor).ToList();
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
