using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePedidos.Models
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }

        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe selecionar un suplidor para realizar la ordén.")]
        public int SuplidorId { get; set; }

        public float Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> Detalle { get; set; }

        public Ordenes()
        {
            OrdenId = 0;
            Fecha = DateTime.Now.Date;
            SuplidorId = 0;
            Monto = 0;
            Detalle = new List<OrdenesDetalle>();
        }
    }
}
