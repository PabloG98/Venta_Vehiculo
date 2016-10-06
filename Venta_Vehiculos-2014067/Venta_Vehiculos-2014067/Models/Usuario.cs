using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Venta_Vehiculos_2014067.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre Completo"), Required(ErrorMessage = "Nombre requerido")]
        public String nombre { get; set; }
        [Display(Name = "Correo"), Required(ErrorMessage = "Correo requerido"), DataType(DataType.EmailAddress)]
        public String correo { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "Contraseña obligatoria"), DataType(DataType.Password)]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "La contraseña debe tener mas de 4 caracteres.")]
        public String contrasena { get; set; }
        [Display(Name = "Comparar contraseña"), Required(ErrorMessage = "Contraseña obligatoria"), DataType(DataType.Password)]
        [Compare("contrasena", ErrorMessage = "Las contraseñas no coinciden")]
        public String compararContrasena { get; set; }
        public int? idRol;
        public virtual Rol rol { get; set; }
    }
}