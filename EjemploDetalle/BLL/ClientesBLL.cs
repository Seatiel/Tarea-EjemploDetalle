using EjemploDetalle.DAL;
using EjemploDetalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjemploDetalle.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            bool retorno = false;
            try
            {
                using (var db = new EjemploDetalleDb())
                {
                    if (Buscar(cliente.ClienteId) == null)
                        db.Cliente.Add(cliente);
                    else
                        db.Entry(cliente).State = EntityState.Modified;

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
                    Clientes user = (from c in db.Cliente where c.ClienteId == id select c).FirstOrDefault();
                    db.Cliente.Remove(user);
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

        public static List<Clientes> GetLista()
        {
            List<Clientes> lista = new List<Clientes>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.Cliente.ToList();
            return lista;
        }

        public static List<Clientes> GetLista(int id)
        {
            List<Clientes> lista = new List<Clientes>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.Cliente.Where(u => u.ClienteId == id).ToList();
            return lista;
        }

        public static Clientes Buscar(int id)
        {
            Clientes client = new Clientes();
            using (EjemploDetalleDb db = new EjemploDetalleDb())
            {
                client = db.Cliente.Find(id);
            }
            return client;
        }

    }
}