using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditarRepuestoModel : PageModel
    {
        private static RepositorioRepuesto repositoriorep=new RepositorioRepuesto(new Persistencia.ContextDb());
        public Repuesto repuestoActual;
        public IEnumerable<Repuesto> listaRepuesto;

        public void OnGet(string id)
        {
            if (id != null)
            {
                this.repuestoActual=repositoriorep.BuscarRepuesto(id);
            }
        }

        public IActionResult OnPostEdit(Repuesto repuesto)
        {
            repositoriorep.EditarRepuesto(repuesto);
            //this.ObtenerRepuestos();
            return RedirectToPage("/Repuestos/GestionRepuestos", new {id = repuesto.RepuestoId});

        }

        public void ObtenerRepuestos()
        {
             this.listaRepuesto=(IEnumerable<Repuesto>)repositoriorep.ObtenerRepuestos();
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
