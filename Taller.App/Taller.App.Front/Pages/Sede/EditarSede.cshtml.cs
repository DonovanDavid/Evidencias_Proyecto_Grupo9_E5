using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditarSedeModel : PageModel
    {
        
        private static RepositorioUbicacion repositorioub=new RepositorioUbicacion(new Persistencia.ContextDb());
        
        public IEnumerable<Ubicacion> listaubicacion;
        
        public Ubicacion ubicacionActual;

        public void OnGet(string id )
        {
            if (id != null)
            {
                this.ubicacionActual=repositorioub.BuscarUbicacion(id);
            }
        }

        public IActionResult OnPostEdit(Ubicacion ubicacion)
        {
            repositorioub.EditarUbicacion(ubicacion);
            //this.ObtenerRepuestos();
            return RedirectToPage("/Sede/GestionSede", new {id = ubicacion.UbicacionId});

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
    }
}
