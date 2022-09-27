using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class GestionRevisionModel : PageModel
    {
        private static RepositorioRevision repositoriorev=new RepositorioRevision(new Persistencia.ContextDb());
        private static RepositorioMecanico repositorio=new RepositorioMecanico(new Persistencia.ContextDb());
        private static RepositorioVehiculo repositoriov=new RepositorioVehiculo(new Persistencia.ContextDb());
        private static RepositorioUbicacion repositorioub=new RepositorioUbicacion(new Persistencia.ContextDb());

        
        public Revision revisionActual;
        
        
        //se crea una nueva lista en este caso para mecanico que llena los select
        public List<Mecanico> listaMecanico=new List<Mecanico>();

        public List<Vehiculo> listaVehiculo=new List<Vehiculo>();

        public List<Ubicacion> listaUbicacion=new List<Ubicacion>();
        
        public IEnumerable<Mecanico> listaMecanic;
        
        public Mecanico mecanicoActual;

        public IEnumerable<Revision> listaRevision;
        
        public Vehiculo vehiculoActual;

        public string textBuscar;

    
        public void OnGet(string id)
        {
            
             if (id !=null)
             {
                this.ObtenerRevisiones(id);
                this.ObtenermMecanicos();
                this.ObtenerVehiculos();
                this.ObtenermUbicaciones();

             }else
             {
                this.ObtenerRevisiones();
                this.ObtenermMecanicos();
                this.ObtenerVehiculos();
                this.ObtenermUbicaciones();
             } 
            
        }

        public void OnPostDel(string id)
        {
            if(id!=null)
            {
                repositoriorev.EliminarRevision(id);
                this.ObtenerRevisiones();

            }
        }

        //creamos el evento siempre OnPost, en este caso para enviar datos desde formulario a base de datos
        public void OnPostAdd(Revision revision)
        {
            Console.WriteLine("Revision: "+revision.PlacaVehiculo);
            repositoriorev.AgregarRevision(revision);
            this.ObtenerRevisiones();

        }

        public void OnPostBuscar(string textBuscar)
        {
            Console.WriteLine("on pos buscar: "+textBuscar);
            this.textBuscar=textBuscar;
            
            this.listaRevision=(IEnumerable<Revision>)repositoriorev.BuscarRevisionVehiculo(textBuscar);
            //var mecanicos=repositorio.BuscarMecanicoNombre(textBuscar);

        }


        public void ObtenerRevisiones()
        {
             this.listaRevision=(IEnumerable<Revision>)repositoriorev.ObtenerRevisiones();
             /*this.listaRevision.Clear();
             foreach (var m in repositoriorev.ObtenerRevisiones())
             {
                this.listaRevision.Add(new Revision(){
                    RevisionId=m.RevisionId,
                    fecharevision=m.fecharevision,
                    hora=m.hora,
                    MecanicoId=m.MecanicoId,
                    PlacaVehiculo=m.PlacaVehiculo,
                });

             }*/
        }

        public void ObtenerRevisiones(string id)
        {
             this.listaRevision=(IEnumerable<Revision>)repositoriorev.ObtenerRevisiones(id);
             /*this.listaRevision.Clear();
             foreach (var m in repositoriorev.ObtenerRevisiones())
             {
                this.listaRevision.Add(new Revision(){
                    RevisionId=m.RevisionId,
                    fecharevision=m.fecharevision,
                    hora=m.hora,
                    MecanicoId=m.MecanicoId,
                    PlacaVehiculo=m.PlacaVehiculo,
                });

             }*/
        }

        public void ObtenerMecanicos()
        {
             this.listaMecanic=(IEnumerable<Mecanico>)repositorio.ObtenerMecanicos();
             //foreach (var m in repositorio.ObtenerMecanicos())
             /*{
                this.listaMecanic.Add(new Mecanico(){
                    MecanicoId=m.MecanicoId,
                nombre=m.nombre,
                telefono=m.telefono,
                fechaNacimiento=m.fechaNacimiento,
                contrasenia=m.contrasenia,
                direccion=m.direccion,
                nivelEstudio=m.nivelEstudio,
                });

             }*/
        }

//se crea esta funcion para efectos de cargar los select y se crea una nueva lista
        public void ObtenermMecanicos()
        {
            this.listaMecanico.Clear();
             foreach (var m in repositorio.ObtenermMecanicos())
             {
                this.listaMecanico.Add(new Mecanico(){
                    MecanicoId=m.MecanicoId,
                nombre=m.nombre,
                telefono=m.telefono,
                fechaNacimiento=m.fechaNacimiento,
                contrasenia=m.contrasenia,
                direccion=m.direccion,
                nivelEstudio=m.nivelEstudio,
                });

             }
        }

        public void ObtenermUbicaciones()
        {
            this.listaUbicacion.Clear();
             foreach (var m in repositorioub.ObtenerUbicaciones())
             {
                this.listaUbicacion.Add(new Ubicacion(){
                    UbicacionId=m.UbicacionId,
                    UbicacionDescripcion=m.UbicacionDescripcion,
                });

             }
        }

         public void ObtenerVehiculos()
        {
             this.listaVehiculo.Clear();
             foreach (var m in repositoriov.ObtenerVehiculos())
             {
                this.listaVehiculo.Add(new Vehiculo(){
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

             }
        }
    }
}
