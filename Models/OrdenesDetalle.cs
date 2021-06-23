using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePedidos.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int Id { get; set; }

        public int OrdenId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public float Costo { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }

    }
}
