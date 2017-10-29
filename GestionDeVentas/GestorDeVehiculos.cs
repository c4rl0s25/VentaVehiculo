using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesAlmacen.Vehiculos;
using InterfacesAlmacen.Vehiculos.Peticiones;
using InterfacesAlmacen.Vehiculos.Respuestas;
using Almacen.Contextos;
using Almacen.Modelos;
namespace GestionDeVentas
{
    public class GestorDeVehiculos : IGestorDeVehiculos
    {

        private VehiculoRegistrado ConvertirVehiculoA_DTO(Vehiculo vehiculo)
        {
            VehiculoRegistrado vehiculoRegistrado = new VehiculoRegistrado();
            vehiculoRegistrado.Id = vehiculo.Id;
            vehiculoRegistrado.Marca = vehiculo.Marca;
            vehiculoRegistrado.Precio = vehiculo.Precio;

            vehiculo.Clientes.ToList()
                .ForEach(
                x =>
                vehiculoRegistrado.NombresDeLosClientes.Add(x.Nombre)
                );
            return vehiculoRegistrado;

        }


        public VehiculoRegistrado CrearVehiculo(NuevoVehiculo NuevoVehiculo)
        {
            using (VentasAutos ventasAutos = new VentasAutos())
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Marca = NuevoVehiculo.Marca;
                vehiculo.Precio = NuevoVehiculo.Precio;

                //select * 
                //    from Clientes 
                //    where ID IN (NuevoVehiculo.IdsDeLosClientes)

                List <Cliente> ClientesElejidos =
                                ventasAutos.Clientes.
                                Where(
                                    x =>
                                    NuevoVehiculo.IdsDeLosClientes.Contains(x.Id)
                                    ).ToList();
                //Agregando clientes al nuevo vehiculo
                ClientesElejidos.ForEach(x=> vehiculo.Clientes.Add(x));
                //Grabando el vehiculo
                ventasAutos.Vehiculos.Add(vehiculo);
                ventasAutos.SaveChanges();
                return ConvertirVehiculoA_DTO(vehiculo);

            }
        }

        public VehiculoRegistrado ActualizarVehiculo(VehiculoActualizado vehiculoActualizado)
        {
            using (VentasAutos ventasAuto = new VentasAutos())
            {
                Vehiculo vehiculo = ventasAuto.Vehiculos.Find(vehiculoActualizado.Id);
                vehiculo.Id = vehiculoActualizado.Id;
                vehiculoActualizado.Precio = vehiculoActualizado.Precio;
                ventasAuto.Entry(vehiculo);
                ventasAuto.SaveChanges();
                return ConvertirVehiculoA_DTO(vehiculo);

            }
        }

        bool IGestorDeVehiculos.BorrarVehiculo(int idDelVehiculo)
        {
            throw new NotImplementedException();
        }


       public List<VehiculoRegistrado> ListarTodosLosVehiculos()
        {
            using (VentasAutos ventasAuto= new VentasAutos())
            {
                return ventasAuto.Vehiculos.ToList().Select(x => ConvertirVehiculoA_DTO(x)).ToList();
            }
        }
    }
}
