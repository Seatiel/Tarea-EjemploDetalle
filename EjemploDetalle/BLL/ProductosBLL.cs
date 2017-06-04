using EjemploDetalle.DAL;
using EjemploDetalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjemploDetalle.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            bool retorno = false;
            try
            {
                using (var db = new EjemploDetalleDb())
                {
                    if (Buscar(productos.ProductoId) == null)
                        db.Producto.Add(productos);
                    else
                        db.Entry(productos).State = EntityState.Modified;

                    db.SaveChanges();
                }
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public static bool Eliminar(int id)
        {
            bool retorno = false;

            try
            {
                using (EjemploDetalleDb db = new EjemploDetalleDb())
                {
                    Productos user = (from c in db.Producto where c.ProductoId == id select c).FirstOrDefault();
                    db.Producto.Remove(user);
                    db.SaveChanges();
                    retorno = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return retorno;
        }

        public static List<Productos> GetLista()
        {
            List<Productos> lista = new List<Productos>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.Producto.ToList();
            return lista;
        }

        public static List<Productos> GetLista(int id)
        {
            List<Productos> lista = new List<Productos>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.Producto.Where(u => u.ProductoId == id).ToList();
            return lista;
        }

        public static Productos Buscar(int id)
        {
            Productos pro = new Productos();
            using (EjemploDetalleDb db = new EjemploDetalleDb())
            {
                pro = db.Producto.Find(id);
            }
            return pro;
        }
    }
}