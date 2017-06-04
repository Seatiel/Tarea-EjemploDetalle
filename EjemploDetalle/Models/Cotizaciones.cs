using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploDetalle.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int ClienteId { get; set; }
        

        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<Models.CotizacionesDetalles> Detalle { get; set; } //Muchos

        public Cotizaciones()
        {
            this.Detalle = new HashSet<Models.CotizacionesDetalles>();
        }

        public Cotizaciones(int cotizacionId, DateTime fecha, int clienteId, decimal monto)
        {
            this.CotizacionId = cotizacionId;
            this.Fecha = fecha;
            this.ClienteId = clienteId;
            this.Monto = monto;
        }

        public void AgregarDetalle(Models.Productos producto, decimal cantidad)
        {
            this.Detalle.Add(new CotizacionesDetalles(producto.ProductoId, producto.Descripcion, cantidad, producto.Precio));
        }
    }
}