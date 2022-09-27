using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditarPropietarioModel : PageModel
    {
        private static RepositorioPropietario repositoriop=new RepositorioPropietario(new Persistencia.ContextDb());
        public IEnumerable<Propietario> listaPropietar;
        public Propietario propietarioActual;

        public void OnGet(string id)
        {
            if (id != null)
            {
                this.propietarioActual=repositoriop.BuscarPropietario(id);
            }
        }

        public IActionResult OnPostEdit(Propietario propietario)
        {
            repositoriop.EditarPropietario(propietario);
            //this.ObtenerRepuestos();
            return RedirectToPage("/Propietarios/GestionPropietario", new {id = propietario.PropietarioId});

        }

        public void ObtenerPropietarios()
        {
             this.listaPropietar=(IEnumerable<Propietario>)repositoriop.ObtenerPropietarios();
             /*this.listaPropietar.Clear();
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

             }*/
        }

    }
}
