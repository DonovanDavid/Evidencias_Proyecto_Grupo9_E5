using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioUbicacion
    {
        private readonly ContextDb contextDb;

        public RepositorioUbicacion(ContextDb contextDb){

            this.contextDb=contextDb;
            
        }
        
        public void AgregarUbicacion(Ubicacion ubicacion)
        {
            this.contextDb.Ubicaciones.Add(ubicacion);
            this.contextDb.SaveChanges();

        }

         public IEnumerable<Ubicacion> ObtenerUbicaciones()
        {
            return this.contextDb.Ubicaciones;
        }

        public IEnumerable<Ubicacion> ObtenerUbicaciones(string id)
        {
            var ubicacion=this.contextDb.Ubicaciones.FirstOrDefault(m=>m.UbicacionId==id);
            this.contextDb.Entry(ubicacion).Reload();
            return this.contextDb.Ubicaciones;
        }

        public Ubicacion BuscarUbicacion(string id)
        {
            try{
                return this.contextDb.Ubicaciones.FirstOrDefault(m=>m.UbicacionId==id);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;

            }
        }

        public void EliminarUbicacion(string id)
        {
            try{
                var ubicacion=this.contextDb.Ubicaciones.FirstOrDefault(m=>m.UbicacionId==id);
                if (ubicacion!=null){
                    this.contextDb.Ubicaciones.Remove(ubicacion);
                    this.contextDb.SaveChanges();

                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }

        }

        public void EditarUbicacion(Ubicacion ubicacionNuevo)
        {
            try{
                var ubicacion=this.contextDb.Ubicaciones.FirstOrDefault(m=>m.UbicacionId==ubicacionNuevo.UbicacionId);
                if (ubicacion!=null){
                    ubicacion.UbicacionId=ubicacionNuevo.UbicacionId;
                    ubicacion.UbicacionDescripcion=ubicacionNuevo.UbicacionDescripcion;
                    this.contextDb.SaveChanges();
                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }

        public IEnumerable<Ubicacion> BuscarUbicacionNombre(string descripcion)
        {
            try{
                string query ="SELECT * from dbo.Ubicaciones WHERE UbicacionDescripcion like '%"+descripcion+"%'"; 
                Console.WriteLine("query: "+query);
               var ubicacion=this.contextDb.Ubicaciones.FromSqlRaw(query).ToList();
            return ubicacion;
            }
             catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;
                
            }

        }
}
}