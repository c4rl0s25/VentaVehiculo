using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAlmacen.Vehiculos.Peticiones
{
    public class NuevoVehiculo
    {
        public string Marca { get; set; }
        public float Precio { get; set; }

        public List<int> IdsDeLosClientes { get; set; }
        public NuevoVehiculo()
        {
     this.IdsDeLosClientes = new List<int>();
        }
    }
}
