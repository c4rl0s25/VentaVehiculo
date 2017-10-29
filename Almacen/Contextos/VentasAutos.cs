using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Almacen.Modelos;
namespace Almacen.Contextos
{
    public class VentasAutos :DbContext
    {
        public VentasAutos(): base("VentasVehiculosDB") { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Concesionario> Concesionarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
