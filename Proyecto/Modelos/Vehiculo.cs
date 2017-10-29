using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelos
{
    public class Vehiculo :BaseEntity
    {
       
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public float Precio { get; set; }

        [ForeignKey("Concesionario")]
        public int ConcesionarioId { get; set; }
        public virtual Concesionario Concesionario { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public Vehiculo() : base()
        {
            this.Clientes = new HashSet<Cliente>();
        }

    }
}
