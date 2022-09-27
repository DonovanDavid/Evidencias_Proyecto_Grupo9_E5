using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioRevision
    {
        private readonly ContextDb contextDb;

        public RepositorioRevision(ContextDb contextDb){

            this.contextDb=contextDb;
        }

        public void AgregarRevision(Revision revision)
        {
            this.contextDb.Revisiones.Add(revision);
            this.contextDb.SaveChanges();
        }

        public IEnumerable<Revision> ObtenerRevisiones()
        {
            return this.contextDb.Revisiones;
        }

        public IEnumerable<Revision> ObtenerRevisiones(string id)
        {
            var revision=this.contextDb.Revisiones.FirstOrDefault(m=>m.RevisionId==id);
            this.contextDb.Entry(revision).Reload();
            return this.contextDb.Revisiones;
        }

        public Revision BuscarRevision(string id)
        {
            try{
                return this.contextDb.Revisiones.FirstOrDefault(m=>m.RevisionId==id);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;

            }
        }

        public Revision BuscarRevisionP(string placa)
        {
            try{
                return this.contextDb.Revisiones.FirstOrDefault(m=>m.PlacaVehiculo==placa);
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;

            }
        }



        public void EliminarRevision(string id)
        {
            try{
                var revision=this.contextDb.Revisiones.FirstOrDefault(m=>m.RevisionId==id);
                if (revision!=null){
                    this.contextDb.Revisiones.Remove(revision);
                    this.contextDb.SaveChanges();

                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
    }

    public void EditarRevision(Revision revisionNuevo)
        {
            try{
                var revision=this.contextDb.Revisiones.FirstOrDefault(m=>m.RevisionId==revisionNuevo.RevisionId);
                if (revision!=null){
                    revision.fecharevision =revisionNuevo.fecharevision;
                    revision.hora=revisionNuevo.hora;
                    revision.MecanicoId=revisionNuevo.MecanicoId;
                    revision.PlacaVehiculo=revisionNuevo.PlacaVehiculo;
                    revision.SedeRevision=revisionNuevo.SedeRevision;
                    revision.DetalleRevision=revisionNuevo.DetalleRevision;
                    revision.EstadoRevision=revisionNuevo.EstadoRevision;
                    this.contextDb.SaveChanges();
                }
            }
            catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                
            }
        }

        public IEnumerable<Revision> BuscarRevisionVehiculo(string placa)
        {
            try{
                string query ="SELECT * from dbo.Revisiones WHERE PlacaVehiculo like '%"+placa+"%'"; 
                Console.WriteLine("query: "+query);
               var revision=this.contextDb.Revisiones.FromSqlRaw(query).ToList();
            return revision;
            }
             catch(System.Exception)
            {
                Console.WriteLine("ocurrio una Exception");
                return null;
                
            }

        }

}
}