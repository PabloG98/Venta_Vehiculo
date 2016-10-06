using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Venta_Vehiculos_2014067.Models
{
    public class Archivo
    {
        [Key]
        public int idFotoVehiculo { get; set; }
        public String nombre { get; set; }
        public byte[] contenido { get; set; }
        public String contentType { get; set; }
        public FileType tipoDeArchvio { get; set; }
        [Display(Name = "Vehiculo")]
        public int idVehiculo { get; set; }
        public virtual Vehiculo vehiculo { get; set; }
    }
}