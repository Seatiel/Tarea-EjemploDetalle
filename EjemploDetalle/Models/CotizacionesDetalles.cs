using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploDetalle.Models
{
    public class CotizacionesDetalles
    {
        [Key]
        public int DetalleId { get; set; }
        public int CotizacionId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        //public Models.Productos Productos { get; set; }
        public virtual Models.Productos Producto { get; set; }
        public virtual Models.Cotizaciones Cotizaciones { get; set; } //Uno

        public CotizacionesDetalles()
        {
            Producto = new Productos();
        }

        public CotizacionesDetalles(int productoId, string descripcion, decimal cantidad, decimal precio)
        {
            this.ProductoId = productoId;
            //this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

    }
}