using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioMecanico
    {
        private readonly ContextDb contextDb;

        public RepositorioMecanico(ContextDb contextDb){

            this.contextDb=contextDb;
        }

        public void AgregarMecanico(Mecanico mecanico)
        {
            this.contextDb.Mecanicos.Add(mecanico);
            this.contextDb.SaveChanges();
        }

        public IEnumerable<Mecanico> ObtenerMecanicos()
        {
            return this.contextDb.Mecanicos;
        }

         public IEnumerable<Mecanico> ObtenerMecanicos(string id)
        {
            var mecanico=this.contextDb.Mecanicos.FirstOrDefault(m=>m.MecanicoId==id);
            this.contextDb.Entry(mecanico).Reload();
            return this.contextDb.Mecanicos;
        }

        public IEnumerable<Mecanico> ObtenermMecanicos()
        {
            return this.contextDb.Mecanicos;
        }

        public Mecanico BuscarMecanico(string id)
        {
            try{
                return this.contextDb.Mecanicos.FirstOrDefault(m=>m.MecanicoId==id);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;

            }
        }

        public IEnumerable<Mecanico> BuscarMecanicoNombre(string nombre)
        {
            try{
                string query ="SELECT * from dbo.Mecanicos WHERE nombre like '%"+nombre+"%'"; 
                Console.WriteLine("query: "+query);
               var mecanic=this.contextDb.Mecanicos.FromSqlRaw(query).ToList();
            return mecanic;
            }
             catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;
                
            }

        }

    

        public void EliminarMecanico(string id)
        {
            try{
                var mecanico=this.contextDb.Mecanicos.FirstOrDefault(m=>m.MecanicoId==id);
                if (mecanico!=null){
                    this.contextDb.Mecanicos.Remove(mecanico);
                    this.contextDb.SaveChanges();

                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }

        }

        public void EditarMecanico(Mecanico mecanicoNuevo)
        {
            try{
                var mecanico=this.contextDb.Mecanicos.FirstOrDefault(m=>m.MecanicoId==mecanicoNuevo.MecanicoId);
                if (mecanico!=null){
                    mecanico.nombre=mecanicoNuevo.nombre;
                    mecanico.telefono=mecanicoNuevo.telefono;
                    mecanico.fechaNacimiento=mecanicoNuevo.fechaNacimiento;
                    mecanico.contrasenia=mecanicoNuevo.contrasenia;
                    mecanico.direccion=mecanicoNuevo.direccion;
                    mecanico.nivelEstudio=mecanicoNuevo.nivelEstudio;
                    this.contextDb.SaveChanges();
                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }
    }
}