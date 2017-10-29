using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using InterfacesAlmacen.Vehiculos;
using InterfacesAlmacen.Vehiculos.Peticiones;
using InterfacesAlmacen.Vehiculos.Respuestas;
using GestionDeVentas;
namespace WpfProyecto.ViewModels
{
    public class MantenimientoVehiculos : INotifyPropertyChanged
    {
        private NuevoVehiculo _nuevoVehiculo = new NuevoVehiculo();

       
        public NuevoVehiculo nuevoVehiculo
        {
            get { return _nuevoVehiculo;  }
            set
            {
                this._nuevoVehiculo = value;
                this.OnPropertyChanged("nuevoVehiculo");
            }
        }

        public void GrabarVehiculo()
        {
            VehiculoRegistrado nuevoVehiculoRegistrado = this._gestorDeVehiculos.CrearVehiculo(this.nuevoVehiculo);
            this.VehiculosRegistrados.Add(nuevoVehiculoRegistrado);
            this.nuevoVehiculo = new NuevoVehiculo();
        }
        public ObservableCollection<VehiculoRegistrado> VehiculosRegistrados { get; set; }
        private IGestorDeVehiculos _gestorDeVehiculos = new GestorDeVehiculos();
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void CargarVehiculo()
        {
            this.VehiculosRegistrados = new ObservableCollection<VehiculoRegistrado>();
            _gestorDeVehiculos.ListarTodosLosVehiculos().ForEach(x=>this.VehiculosRegistrados.Add(x));
        }


       
    }
}
