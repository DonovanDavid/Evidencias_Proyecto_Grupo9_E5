using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio
{
    public class Revision
    {
        public string RevisionId {get;set;}
        public string fecharevision {get;set;}
        public string hora {get;set;}

        public string MecanicoId {get;set;}

        public Mecanico Mecanico {get;set;}

        public string PlacaVehiculo {get;set;}

        public Vehiculo Vehiculo {get;set;}

        public string SedeRevision {get;set;}

        public string DetalleRevision {get;set;}

        public string EstadoRevision {get;set;}

    }
}