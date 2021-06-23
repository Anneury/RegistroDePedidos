using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePedidos.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Debe agregar una descripción del producto.")]
        public string Descripcion { get; set; }
       
        public float Costo { get; set; }
        
        public float Inventario { get; set; }
    }
}
