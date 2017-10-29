namespace Almacen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Dni = c.Int(nullable: false),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehiculo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Color = c.String(),
                        Precio = c.Single(nullable: false),
                        ConcesionarioId = c.Int(nullable: false),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concesionario", t => t.ConcesionarioId, cascadeDelete: true)
                .Index(t => t.ConcesionarioId);
            
            CreateTable(
                "dbo.Concesionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Distrito = c.String(),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehiculoCliente",
                c => new
                    {
                        Vehiculo_Id = c.Int(nullable: false),
                        Cliente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehiculo_Id, t.Cliente_Id })
                .ForeignKey("dbo.Vehiculo", t => t.Vehiculo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id, cascadeDelete: true)
                .Index(t => t.Vehiculo_Id)
                .Index(t => t.Cliente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculo", "ConcesionarioId", "dbo.Concesionario");
            DropForeignKey("dbo.VehiculoCliente", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.VehiculoCliente", "Vehiculo_Id", "dbo.Vehiculo");
            DropIndex("dbo.VehiculoCliente", new[] { "Cliente_Id" });
            DropIndex("dbo.VehiculoCliente", new[] { "Vehiculo_Id" });
            DropIndex("dbo.Vehiculo", new[] { "ConcesionarioId" });
            DropTable("dbo.VehiculoCliente");
            DropTable("dbo.Concesionario");
            DropTable("dbo.Vehiculo");
            DropTable("dbo.Cliente");
        }
    }
}
