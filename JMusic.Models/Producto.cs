using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace JMusic.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<DetalleOrden> DetalleOrden { get; set; }
    }
}
