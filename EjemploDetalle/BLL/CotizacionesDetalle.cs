using EjemploDetalle.DAL;
using EjemploDetalle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjemploDetalle.BLL
{
    public class CotizacionesDetalle
    {
        public static bool Guardar(CotizacionesDetalles detalle)
        {
            bool retorno = false;
            try
            {
                using (var db = new EjemploDetalleDb())
                {
                    if (Buscar(detalle.DetalleId) == null)
                        db.CotizacionDetalle.Add(detalle);
                    else
                        db.Entry(detalle).State = EntityState.Modified;

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
                    CotizacionesDetalles user = (from c in db.CotizacionDetalle where c.DetalleId == id select c).FirstOrDefault();
                    db.CotizacionDetalle.Remove(user);
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

        public static List<CotizacionesDetalles> GetLista()
        {
            List<CotizacionesDetalles> lista = new List<CotizacionesDetalles>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.CotizacionDetalle.ToList();
            return lista;
        }

        public static List<CotizacionesDetalles> GetLista(int id)
        {
            List<CotizacionesDetalles> lista = new List<CotizacionesDetalles>();
            EjemploDetalleDb db = new EjemploDetalleDb();

            lista = db.CotizacionDetalle.Where(u => u.DetalleId == id).ToList();
            return lista;
        }

        public static CotizacionesDetalles Buscar(int id)
        {
            CotizacionesDetalles cotizacion = new CotizacionesDetalles();
            using (EjemploDetalleDb db = new EjemploDetalleDb())
            {
                cotizacion = db.CotizacionDetalle.Find(id);
            }
            return cotizacion;
        }
    }
}