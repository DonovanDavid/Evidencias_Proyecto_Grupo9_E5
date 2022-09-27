using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio
{
    public class Propietario : Persona{
        public string PropietarioId {get;set;}
        public string ciudad {get;set;}
        public string correo {get;set;}
    }
}