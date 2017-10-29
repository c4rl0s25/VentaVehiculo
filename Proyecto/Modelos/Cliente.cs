using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelos
{
    public class Cliente : BaseEntity
    {
       
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Dni { get; set; }

        public ICollection<Vehiculo> vehiculos { get; set; }

        public Cliente() :base()
        {
            this.vehiculos = new HashSet<Vehiculo>();
        }
    }
}
