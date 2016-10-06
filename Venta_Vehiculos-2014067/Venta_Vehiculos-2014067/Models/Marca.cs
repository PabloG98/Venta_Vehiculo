using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Venta_Vehiculos_2014067.Models
{
    public class Marca
    {
        [Key]
        public int idMarca { get; set; }
        [Display(Name = "Marca del Vehiculo"), Required(ErrorMessage = "La marca del Vehiculo es obligatoria"), DataType(DataType.Text)]
        public String nombre { get; set; }
        public virtual List<Vehiculo> vehiculos { get; set; }
    }
}