using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Venta_Vehiculos_2014067.Models
{
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }
        [Display(Name = "Fecha de la venta del vehiculo"), Required(ErrorMessage = "Fecha obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0_yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaVenta { get; set; }
        public int idVehiculo { get; set; }
        public int idUsuario { get; set; }

        public virtual Vehiculo vehiculo { get; set; }
        public virtual Usuario usuario { get; set; }
    }
}