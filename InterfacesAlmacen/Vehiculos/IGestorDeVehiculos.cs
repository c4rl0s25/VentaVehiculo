using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesAlmacen.Vehiculos.Peticiones;
using InterfacesAlmacen.Vehiculos.Respuestas;
namespace InterfacesAlmacen.Vehiculos
{
   public interface IGestorDeVehiculos
    {
        VehiculoRegistrado CrearVehiculo(NuevoVehiculo NuevoVehiculo);
        List<VehiculoRegistrado> ListarTodosLosVehiculos();

        VehiculoRegistrado ActualizarVehiculo(VehiculoActualizado vehiculoActualizado);

        bool BorrarVehiculo(int idDelVehiculo);
        
    }
}
