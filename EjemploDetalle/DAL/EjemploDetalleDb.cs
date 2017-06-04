using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EjemploDetalle.DAL
{
    public class EjemploDetalleDb : DbContext 
    {
        public EjemploDetalleDb() : base("ConStr")
        {

        }
        public DbSet<Models.Clientes> Cliente { get; set; }
        public DbSet<Models.Cotizaciones> Cotizacion { get; set; }
        public DbSet<Models.Productos> Producto { get; set; }
        public DbSet<Models.CotizacionesDetalles> CotizacionDetalle { get; set; }


    }
}