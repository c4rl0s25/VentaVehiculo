using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almacen.Compartido;
namespace Almacen.Modelos
{
    public class Concesionario :BaseEntity
    {
       
        public string Nombre { get; set; }
        public string Distrito { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public Concesionario() :base ()
        {
            this.Vehiculos = new HashSet<Vehiculo>();
            
        }
    }
}
