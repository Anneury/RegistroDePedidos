using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePedidos.Models
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Debe asignarle un nombre al suplidor.")]
        public string Nombres { get; set; }
    }
}
