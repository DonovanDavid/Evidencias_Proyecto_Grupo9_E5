using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class GestionRepuestosModel : PageModel
    {
        private static RepositorioRepuesto repositoriorep=new RepositorioRepuesto(new Persistencia.ContextDb());
        //public List<Repuesto> listaRepuesto=new List<Repuesto>();
        public IEnumerable<Repuesto> listaRepuesto;
        public Repuesto repuestoActual;

        public string textBuscar;

        public void OnGet(string id)
        {
             if (id !=null)
             {
                this.ObtenerRepuestos(id);

             }else
             {
                this.ObtenerRepuestos();
             }       

             }
             

        public void OnPostDel(string id)
        {
            if(id!=null)
            {
                repositoriorep.EliminarRepuesto(id);
                this.ObtenerRepuestos();

            }
        }

        public void OnPostAdd(Repuesto repuesto)
        {
            Console.WriteLine("Repuesto: "+repuesto.RepuestoId);
            repositoriorep.AgregarRepuesto(repuesto);
            this.ObtenerRepuestos();

        }

        public void OnPostBuscar(string textBuscar)
        {
            Console.WriteLine("on pos buscar: "+textBuscar);
            this.textBuscar=textBuscar;           
            this.listaRepuesto=(IEnumerable<Repuesto>)repositoriorep.BuscarRepuestoDescripcion(textBuscar);
            //var mecanicos=repositorio.BuscarMecanicoNombre(textBuscar);

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

        public void ObtenerRepuestos(string id)
        {
             this.listaRepuesto=(IEnumerable<Repuesto>)repositoriorep.ObtenerRepuestos(id);
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
