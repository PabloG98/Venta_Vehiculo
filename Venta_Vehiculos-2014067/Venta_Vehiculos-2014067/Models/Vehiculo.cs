using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Venta_Vehiculos_2014067.Models
{
    public class Vehiculo
    {
        [Key]
        public int idVehiculo { get; set; }
        [Display(Name = "Modelo del Vehiculo"), Required(ErrorMessage = "La modelo del Vehiculo es obligatoria"), DataType(DataType.Text)]
        public String Modelo { get; set; }
        [Display(Name = "Color del Vehiculo"), Required(ErrorMessage = "El color del Vehiculo es obligatoria"), DataType(DataType.Text)]
        public String Color { get; set; }
        [Display(Name = "Tipo de combustible del Vehiculo"), Required(ErrorMessage = "El tipo de combustible del Vehiculo es obligatoria"), DataType(DataType.Text)]
        public String tipoCombustible { get; set; }
        [Display(Name = "Precio del Vehiculo"), Required(ErrorMessage = "El precio del Vehiculo es obligatoria"), DataType(DataType.Text)]
        public String precio { get; set; }
        public virtual List<Archivo> foto { get; set; }
        public int idMarca;
        public virtual Marca marca { get; set; }
        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Venta> venta { get; set; }
        public virtual List<Compra> compra { get; set; }
    }
}