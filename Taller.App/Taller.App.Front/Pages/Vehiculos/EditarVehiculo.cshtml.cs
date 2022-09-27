using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditarVehiculoModel : PageModel
    {
        
        private static RepositorioVehiculo repositoriov=new RepositorioVehiculo(new Persistencia.ContextDb());
        private static RepositorioPropietario repositoriop=new RepositorioPropietario(new Persistencia.ContextDb());

        public IEnumerable<Vehiculo> listaVehic;
        
        public List<Propietario> listaPropietar=new List<Propietario>();

        public Propietario propietarioActual;

        public Vehiculo vehiculoActual;

        public string textBuscar;

        public void OnGet(string id)
        {
            if (id != null)
            {
                this.vehiculoActual=repositoriov.BuscarVehiculo(id);
            }
        }

        public IActionResult OnPostEdit(Vehiculo vehiculo)
        {
            repositoriov.EditarVehiculo(vehiculo);
            //this.ObtenerRepuestos();
            return RedirectToPage("/Vehiculos/GestionVehiculo", new {id = vehiculo.PlacaVehiculo});

        }

         public void ObtenerVehiculos()
        {
             this.listaVehic=(IEnumerable<Vehiculo>)repositoriov.ObtenerVehiculos();
             /*this.listaVehic.Clear();
             foreach (var m in repositoriov.ObtenerVehiculos())
             {
                this.listaVehic.Add(new Vehiculo(){
                VehiculoId=m.VehiculoId,
                PlacaVehiculo=m.PlacaVehiculo,
                PropietarioVehiculo=m.PropietarioVehiculo,
                MarcaVehiculo=m.MarcaVehiculo,
                LineaVehiculo=m.LineaVehiculo,
                ModeloVehiculo=m.ModeloVehiculo,
                ColorVehiculo=m.ColorVehiculo,
                MotorVehiculo =m.MotorVehiculo ,
                ChasisVehiculo=m.ChasisVehiculo,
                CapacidadVehiculo=m.CapacidadVehiculo,
                CilindrajeVehiculo=m.CilindrajeVehiculo,
                TipoVehiculo=m.TipoVehiculo,
                CiudadVehiculo=m.CiudadVehiculo,
                CaracteristicasVehiculo=m.CaracteristicasVehiculo,
                });

             }*/
        }

          public void ObtenerPropietarios()
        {
             this.listaPropietar.Clear();
             foreach (var m in repositoriop.ObtenerPropietarios())
             {
                this.listaPropietar.Add(new Propietario(){
                PropietarioId=m.PropietarioId,
                nombre=m.nombre,
                telefono=m.telefono,
                fechaNacimiento=m.fechaNacimiento,
                contrasenia=m.contrasenia,
                ciudad=m.ciudad,
                correo=m.correo,
                });

             }
        }
    }
}
