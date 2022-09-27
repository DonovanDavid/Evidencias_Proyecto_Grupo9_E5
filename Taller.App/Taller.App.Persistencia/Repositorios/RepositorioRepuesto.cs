using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioRepuesto
    {
        private readonly ContextDb contextDb;

        public RepositorioRepuesto(ContextDb contextDb){

            this.contextDb=contextDb;
            
        }

        public void AgregarRepuesto(Repuesto repuesto)
        {
            this.contextDb.Repuestos.Add(repuesto);
            this.contextDb.SaveChanges();

        }

        public IEnumerable<Repuesto> ObtenerRepuestos()
        {
            return this.contextDb.Repuestos;
        }

        public IEnumerable<Repuesto> ObtenerRepuestos(string id)
        {
            var repuesto=this.contextDb.Repuestos.FirstOrDefault(m=>m.RepuestoId==id);
            this.contextDb.Entry(repuesto).Reload();
            return this.contextDb.Repuestos;
        }

        public Repuesto BuscarRepuesto(string id)
        {
            try{
                return this.contextDb.Repuestos.FirstOrDefault(m=>m.RepuestoId==id);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;

            }
        }

         public void EliminarRepuesto(string id)
        {
            try{
                var repuesto=this.contextDb.Repuestos.FirstOrDefault(m=>m.RepuestoId==id);
                if (repuesto!=null){
                    this.contextDb.Repuestos.Remove(repuesto);
                    this.contextDb.SaveChanges();

                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }

        }

        public void EditarRepuesto(Repuesto repuestoNuevo)
        {
            try{
                var repuesto=this.contextDb.Repuestos.FirstOrDefault(m=>m.RepuestoId==repuestoNuevo.RepuestoId);
                if (repuesto!=null){
                    repuesto.descripcion=repuestoNuevo.descripcion;
                    repuesto.cantidad=repuestoNuevo.cantidad;
                    repuesto.precio=repuestoNuevo.precio;
                    this.contextDb.SaveChanges();
                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }

         public IEnumerable<Repuesto> BuscarRepuestoDescripcion(string descripcion)
        {
            try{
                string query ="SELECT * from dbo.Repuestos WHERE descripcion like '%"+descripcion+"%'"; 
                Console.WriteLine("query: "+query);
               var repuesto=this.contextDb.Repuestos.FromSqlRaw(query).ToList();
            return repuesto;
            }
             catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;
                
            }

        }
    }
}