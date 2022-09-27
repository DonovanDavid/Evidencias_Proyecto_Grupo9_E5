using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;


namespace Taller.App.Front.Pages
{
    public class GestionPropietarioModel : PageModel
    {
        //cargar una lista sin la base de datos, 
        //public List<Propietar> listaPropietar=new List<Propietar>(){
            //new Propietar(){nombre="fredy", apellidos="llantero", telefono="neiva", nacimiento="01/10/1991", correo="kkmadrid@hotmail.com"},
            //new Propietar(){nombre="fredy", apellidos="llantero", telefono="neiva", nacimiento="01/10/1991", correo="kkmadrid@hotmail.com"},
            //new Propietar(){nombre="fredy", apellidos="llantero", telefono="neiva", nacimiento="01/10/1991", correo="kkmadrid@hotmail.com"}
            
        //};

        private static RepositorioPropietario repositoriop=new RepositorioPropietario(new Persistencia.ContextDb());

        public IEnumerable<Propietario> listaPropietar;

        public Propietario propietarioActual;

        public string textBuscar;

        public void OnGet(string id)
        {
            
            if (id !=null)
             {
                this.ObtenerPropietarios(id);;

             }else
             {
                this.ObtenerPropietarios();
             } 

            
        }

        public void OnPostDel(string id)
        {
            if(id!=null)
            {
                repositoriop.EliminarPropietario(id);
                this.ObtenerPropietarios();

            }
        }
        
        public void OnPostAdd(Propietario propietario)
        {
            Console.WriteLine("Propietario: "+propietario.nombre);
            repositoriop.AgregarPropietario(propietario);
            this.ObtenerPropietarios();

        }

         public void OnPostBuscar(string textBuscar)
        {
            Console.WriteLine("on pos buscar: "+textBuscar);
            this.textBuscar=textBuscar;
            
            this.listaPropietar=(IEnumerable<Propietario>)repositoriop.BuscarPropietarioNombre(textBuscar);
            //var mecanicos=repositorio.BuscarMecanicoNombre(textBuscar);

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

        public void ObtenerPropietarios(string id)
        {
             this.listaPropietar=(IEnumerable<Propietario>)repositoriop.ObtenerPropietarios(id);
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
