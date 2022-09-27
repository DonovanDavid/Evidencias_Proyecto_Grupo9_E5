using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class GestionSedeModel : PageModel
    {
        private static RepositorioUbicacion repositorioub=new RepositorioUbicacion(new Persistencia.ContextDb());
        
        public IEnumerable<Ubicacion> listaubicacion;
        
        public Ubicacion ubicacionActual;

        public string textBuscar;

        public void OnGet(string id)
        {
            if(id !=null)
            {
            this.ObtenerUbicaciones(id);
            }else{
                this.ObtenerUbicaciones();
            }
        }

        public void OnPostDel(string id)
        {
            if(id!=null)
            {
                repositorioub.EliminarUbicacion(id);
                this.ObtenerUbicaciones();

            }
        }

        public void OnPostAdd(Ubicacion ubicacion)
        {
            Console.WriteLine("Repuesto: "+ubicacion.UbicacionId);
            repositorioub.AgregarUbicacion(ubicacion);
            this.ObtenerUbicaciones();

        }

        public void OnPostBuscar(string textBuscar)
        {
            Console.WriteLine("on pos buscar: "+textBuscar);
            this.textBuscar=textBuscar;           
            this.listaubicacion=(IEnumerable<Ubicacion>)repositorioub.BuscarUbicacionNombre(textBuscar);
            //var mecanicos=repositorio.BuscarMecanicoNombre(textBuscar);

        }

        public void ObtenerUbicaciones()
        {
             this.listaubicacion=(IEnumerable<Ubicacion>)repositorioub.ObtenerUbicaciones();
             /*this.listaRepuesto.Clear();
             foreach (var m in repositoriorep.ObtenerRepuestos())
             {
                this.listaRepuesto.Add(new Repuesto(){
                    RepuestoId=m.RepuestoId,
                    descripcion=m.descripcion,
                    cantidad=m.cantidad,
                    precio=m.precio,
                });

             }*/
        }

        public void ObtenerUbicaciones(string id)
        {
             this.listaubicacion=(IEnumerable<Ubicacion>)repositorioub.ObtenerUbicaciones(id);
             /*this.listaRepuesto.Clear();
             foreach (var m in repositoriorep.ObtenerRepuestos())
             {
                this.listaRepuesto.Add(new Repuesto(){
                    RepuestoId=m.RepuestoId,
                    descripcion=m.descripcion,
                    cantidad=m.cantidad,
                    precio=m.precio,
                });

             }*/
        }
    }
}

