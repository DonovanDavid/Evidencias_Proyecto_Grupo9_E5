using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class GestionMecanicoModel : PageModel
    {
        private static RepositorioMecanico repositorio=new RepositorioMecanico(new Persistencia.ContextDb());
        private static RepositorioPropietario repositoriop=new RepositorioPropietario(new Persistencia.ContextDb());

        public IEnumerable<Mecanico> listaMecanic;

        public Mecanico mecanicoActual;

        
       
       public string textBuscar;

        public void OnGet(string id)
        {
             if (id !=null)
             {
                this.ObtenerMecanicos(id);;

             }else
             {
                this.ObtenerMecanicos();
             } 
            
            ;

        }

        public void OnPostDel(string id)
        {
            if(id!=null)
            {
                repositorio.EliminarMecanico(id);
                this.ObtenerMecanicos();

            }
        }

        public void OnPostBuscar(string textBuscar)
        {
            Console.WriteLine("on pos buscar: "+textBuscar);
            this.textBuscar=textBuscar;
            
            this.listaMecanic=(IEnumerable<Mecanico>)repositorio.BuscarMecanicoNombre(textBuscar);
            //var mecanicos=repositorio.BuscarMecanicoNombre(textBuscar);

        }

        //creamos el evento siempre OnPost, en este caso para enviar datos desde formulario a base de datos
        public void OnPostAdd(Mecanico mecanico)
        {
            Console.WriteLine("Mecanico: "+mecanico.nivelEstudio);
            repositorio.AgregarMecanico(mecanico);
            this.ObtenerMecanicos();

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

        public void ObtenerMecanicos(string id)
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
