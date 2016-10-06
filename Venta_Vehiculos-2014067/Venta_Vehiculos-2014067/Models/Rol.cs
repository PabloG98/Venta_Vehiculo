using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Venta_Vehiculos_2014067.Models
{
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public String nombre { get; set; }
        [Display(Name = "descripcion")]
        [Required(ErrorMessage = "Descripcion obligatoria")]
        public String descripcion { get; set; }
        public virtual List<Usuario> usuarios { get; set; }
    }
}