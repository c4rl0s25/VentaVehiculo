namespace Almacen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermitirNulloCategoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculo", "ConcesionarioId", "dbo.Concesionario");
            DropIndex("dbo.Vehiculo", new[] { "ConcesionarioId" });
            AlterColumn("dbo.Vehiculo", "ConcesionarioId", c => c.Int());
            CreateIndex("dbo.Vehiculo", "ConcesionarioId");
            AddForeignKey("dbo.Vehiculo", "ConcesionarioId", "dbo.Concesionario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculo", "ConcesionarioId", "dbo.Concesionario");
            DropIndex("dbo.Vehiculo", new[] { "ConcesionarioId" });
            AlterColumn("dbo.Vehiculo", "ConcesionarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehiculo", "ConcesionarioId");
            AddForeignKey("dbo.Vehiculo", "ConcesionarioId", "dbo.Concesionario", "Id", cascadeDelete: true);
        }
    }
}
