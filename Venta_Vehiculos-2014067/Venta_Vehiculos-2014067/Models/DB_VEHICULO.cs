using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Venta_Vehiculos_2014067.Models
{
    public class DB_VEHICULO : DbContext
    {
        public DB_VEHICULO() : base("name=DB_Vehiculo") { }

        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Vehiculo> vehiculo { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Venta> venta { get; set; }
        
    }
}