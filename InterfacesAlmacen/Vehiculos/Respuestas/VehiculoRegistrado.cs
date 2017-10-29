using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAlmacen.Vehiculos.Respuestas
{
    public class VehiculoRegistrado
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }

        public List<string> NombresDeLosClientes { get; set; }

        public VehiculoRegistrado()
        {
            this.NombresDeLosClientes = new List<string>();
        }
    }
}
