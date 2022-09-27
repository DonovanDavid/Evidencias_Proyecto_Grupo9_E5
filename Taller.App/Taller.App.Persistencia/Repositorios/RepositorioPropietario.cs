using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioPropietario
    {
        private readonly ContextDb contextDb;

        public RepositorioPropietario(ContextDb contextDb){

            this.contextDb=contextDb;
    }

    public void AgregarPropietario(Propietario propietario)
        {
            this.contextDb.Propietarios.Add(propietario);
            this.contextDb.SaveChanges();
        }

     public IEnumerable<Propietario> ObtenerPropietarios()
        {
            return this.contextDb.Propietarios;
        }

        public IEnumerable<Propietario> ObtenerPropietarios(string id)
        {
            var propietario=this.contextDb.Propietarios.FirstOrDefault(m=>m.PropietarioId==id);
            this.contextDb.Entry(propietario).Reload();
            return this.contextDb.Propietarios;
        }   

        public Propietario BuscarPropietario(string id)
        {
            try{
                return this.contextDb.Propietarios.FirstOrDefault(m=>m.PropietarioId==id);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;}

        } 

        public void EliminarPropietario(string id)
        {
            try{
                var propietario=this.contextDb.Propietarios.FirstOrDefault(m=>m.PropietarioId==id);
                if (propietario!=null){
                    this.contextDb.Propietarios.Remove(propietario);
                    this.contextDb.SaveChanges();

                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }

        }  

        public void EditarPropietario(Propietario propietarioNuevo)
        {
            try{
                var propietario=this.contextDb.Propietarios.FirstOrDefault(m=>m.PropietarioId==propietarioNuevo.PropietarioId);
                if (propietario!=null){
                    propietario.nombre=propietarioNuevo.nombre;
                    propietario.telefono=propietarioNuevo.telefono;
                    propietario.fechaNacimiento=propietarioNuevo.fechaNacimiento;
                    propietario.contrasenia=propietarioNuevo.contrasenia;
                    propietario.ciudad=propietarioNuevo.ciudad;
                    propietario.correo=propietarioNuevo.correo;
                    this.contextDb.SaveChanges();
                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }

        public IEnumerable<Propietario> BuscarPropietarioNombre(string nombre)
        {
            try{
                string query ="SELECT * from dbo.Propietarios WHERE nombre like '%"+nombre+"%'"; 
                Console.WriteLine("query: "+query);
               var propietario=this.contextDb.Propietarios.FromSqlRaw(query).ToList();
            return propietario;
            }
             catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;
                
            }

        }
}
}