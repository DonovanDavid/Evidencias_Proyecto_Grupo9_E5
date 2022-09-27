using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class EditarMecanicoModel : PageModel
    {
        private static RepositorioMecanico repositorio=new RepositorioMecanico(new Persistencia.ContextDb());
        private static RepositorioPropietario repositoriop=new RepositorioPropietario(new Persistencia.ContextDb());

        public IEnumerable<Mecanico> listaMecanic;

        public Mecanico mecanicoActual;

        public void OnGet(string id)
        {
            this.mecanicoActual=repositorio.BuscarMecanico(id);
        }

        public IActionResult OnPostEdit(Mecanico mecanico)
        {
            repositorio.EditarMecanico(mecanico);
            //this.ObtenerRepuestos();
            return RedirectToPage("/GestionMecanico/GestionMecanico", new {id = mecanico.MecanicoId});

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
    }
}
