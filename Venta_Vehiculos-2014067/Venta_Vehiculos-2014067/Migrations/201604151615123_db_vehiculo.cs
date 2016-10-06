namespace Venta_Vehiculos_2014067.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_vehiculo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        idArchivo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        contentType = c.String(),
                        tipo = c.Int(nullable: false),
                        contenido = c.Binary(),
                        vehiculo_idVehiculo = c.Int(),
                    })
                .PrimaryKey(t => t.idArchivo)
                .ForeignKey("dbo.Vehiculoes", t => t.vehiculo_idVehiculo)
                .Index(t => t.vehiculo_idVehiculo);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        idVehiculo = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        tipoCombustible = c.String(nullable: false),
                        precio = c.String(nullable: false),
                        idMarca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVehiculo)
                .ForeignKey("dbo.Marcas", t => t.idMarca, cascadeDelete: true)
                .Index(t => t.idMarca);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        idCompra = c.Int(nullable: false, identity: true),
                        fechaCompra = c.DateTime(nullable: false),
                        idVehiculo = c.Int(nullable: false),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCompra)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.idVehiculo, cascadeDelete: true)
                .Index(t => t.idVehiculo)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        contrasena = c.String(nullable: false, maxLength: 5),
                        compararContrasena = c.String(nullable: false),
                        rol_idRol = c.Int(),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Rols", t => t.rol_idRol)
                .Index(t => t.rol_idRol);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        idMarca = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idMarca);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        idVenta = c.Int(nullable: false, identity: true),
                        fechaVenta = c.DateTime(nullable: false),
                        idVehiculo = c.Int(nullable: false),
                        idUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.idVehiculo, cascadeDelete: true)
                .Index(t => t.idVehiculo)
                .Index(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "idVehiculo", "dbo.Vehiculoes");
            DropForeignKey("dbo.Ventas", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Vehiculoes", "idMarca", "dbo.Marcas");
            DropForeignKey("dbo.Compras", "idVehiculo", "dbo.Vehiculoes");
            DropForeignKey("dbo.Compras", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "rol_idRol", "dbo.Rols");
            DropForeignKey("dbo.Archivoes", "vehiculo_idVehiculo", "dbo.Vehiculoes");
            DropIndex("dbo.Ventas", new[] { "idUsuario" });
            DropIndex("dbo.Ventas", new[] { "idVehiculo" });
            DropIndex("dbo.Usuarios", new[] { "rol_idRol" });
            DropIndex("dbo.Compras", new[] { "idUsuario" });
            DropIndex("dbo.Compras", new[] { "idVehiculo" });
            DropIndex("dbo.Vehiculoes", new[] { "idMarca" });
            DropIndex("dbo.Archivoes", new[] { "vehiculo_idVehiculo" });
            DropTable("dbo.Ventas");
            DropTable("dbo.Marcas");
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Compras");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Archivoes");
        }
    }
}
