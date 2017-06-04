using EjemploDetalle.DAL;
using EjemploDetalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjemploDetalle.BLL
{
    public class CotizacionesBLL
    {
        public static bool Guardar(Cotizaciones cotizacion)
        {
            bool retorno = false;
            try
            {
                using (var db = new EjemploDetalleDb())
                {
                    if (Buscar(cotizacion.CotizacionId) == null)
                        db.Cotizacion.Add(cotizacion);
                    else
                        db.Entry(cotizacion).State = EntityState.Modified;

                    foreach (var cotizaciones in cotizacion.Detalle)
                    {
                        db.Entry(cotizaciones).State = EntityState.Unchanged;
                    }
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

        public static Cotizaciones Buscar(int id)
        {
            Cotizaciones date = null;
            using (var db = new EjemploDetalleDb())
            {
                date = db.Cotizacion.Find(id);
                if (date != null)
                    date.Detalle.Count();
            }
            return date;
        }

        public static bool Eliminar(int id)
        {
            bool retorno = false;

            try
            {
                using (EjemploDetalleDb db = new EjemploDetalleDb())
                {
                    Cotizaciones fact = (from c in db.Cotizacion where c.CotizacionId == id select c).FirstOrDefault();
                    db.Cotizacion.Remove(fact);
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

        public static List<Cotizaciones> GetLista()
        {
            List<Cotizaciones> lista = new List<Cotizaciones>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.Cotizacion.ToList();
            return lista;
        }

        public static List<Cotizaciones> GetLista(int id)
        {
            List<Cotizaciones> lista = new List<Cotizaciones>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.Cotizacion.Where(u => u.CotizacionId == id).ToList();
            return lista;
        }
    }
}