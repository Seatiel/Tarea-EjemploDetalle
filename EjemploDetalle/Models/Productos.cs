using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploDetalle.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }        
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<Models.CotizacionesDetalles> ProductosDetalle { get; set; }

        public Productos()
        {
            this.ProductosDetalle = new HashSet<CotizacionesDetalles>();
        }

        public override string ToString()
        {
            return string.Format("ProductoId: {0}, Descripción: {1}", this.ProductoId, this.Descripcion);
        }

    }
}