using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Venta_Vehiculos_2014067.Models
{
    public class Compra
    {
        [Key]
        public int idCompra { get; set; }
        [Display(Name = "Fecha de la compra del vehiculo"), Required(ErrorMessage = "Fecha obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0_yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }
        public int idVehiculo { get; set; }
        public int idUsuario { get; set; }

        public virtual Vehiculo vehiculo { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}