using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioVehiculo
    {
         private readonly ContextDb contextDb;

         public RepositorioVehiculo(ContextDb contextDb)
         {

            this.contextDb=contextDb;
         }

    public void AgregarVehiculo(Vehiculo vehiculo)
        {
            this.contextDb.Vehiculos.Add(vehiculo);
            this.contextDb.SaveChanges();
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            return this.contextDb.Vehiculos;
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos(string id)
        {
            var vehiculo=this.contextDb.Vehiculos.FirstOrDefault(m=>m.PlacaVehiculo==id);
            this.contextDb.Entry(vehiculo).Reload();
            return this.contextDb.Vehiculos;
        }



        public Vehiculo BuscarVehiculo(string placa)
        {
            try{
                return this.contextDb.Vehiculos.FirstOrDefault(m=>m.PlacaVehiculo==placa);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;}

        } 

        public void EliminarVehiculo(string id)
        {
            try{
                var vehiculo=this.contextDb.Vehiculos.FirstOrDefault(m=>m.VehiculoId==id);
                if (vehiculo!=null){
                    this.contextDb.Vehiculos.Remove(vehiculo);
                    this.contextDb.SaveChanges();

                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }

         public void EditarVehiculo(Vehiculo vehiculoNuevo)
        {
            try{
                var vehiculo=this.contextDb.Vehiculos.FirstOrDefault(m=>m.PlacaVehiculo==vehiculoNuevo.PlacaVehiculo);
                if (vehiculo!=null){
                    vehiculo.PropietarioVehiculo=vehiculoNuevo.PropietarioVehiculo;
                    vehiculo.MarcaVehiculo=vehiculoNuevo.MarcaVehiculo;
                    vehiculo.LineaVehiculo=vehiculoNuevo.LineaVehiculo;
                    vehiculo.ModeloVehiculo=vehiculoNuevo.ModeloVehiculo;
                    vehiculo.ColorVehiculo=vehiculoNuevo.ColorVehiculo;
                    vehiculo.MotorVehiculo=vehiculoNuevo.MotorVehiculo;
                    vehiculo.ChasisVehiculo=vehiculoNuevo.ChasisVehiculo;
                    vehiculo.CapacidadVehiculo=vehiculoNuevo.CapacidadVehiculo;
                    vehiculo.CilindrajeVehiculo=vehiculoNuevo.CilindrajeVehiculo;
                    vehiculo.TipoVehiculo=vehiculoNuevo.TipoVehiculo;
                    vehiculo.CiudadVehiculo=vehiculoNuevo.CiudadVehiculo;
                    vehiculo.CaracteristicasVehiculo=vehiculoNuevo.CaracteristicasVehiculo;
                    this.contextDb.SaveChanges();
                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }

        public IEnumerable<Vehiculo> BuscarVehiculoPlaca(string placa)
        {
            try{
                string query ="SELECT * from dbo.Vehiculos WHERE PlacaVehiculo like '%"+placa+"%'"; 
                Console.WriteLine("query: "+query);
               var vehiculo=this.contextDb.Vehiculos.FromSqlRaw(query).ToList();
            return vehiculo;
            }
             catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;
                
            }

        }


}
}