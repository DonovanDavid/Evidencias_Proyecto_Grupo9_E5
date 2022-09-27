using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;

namespace Taller.App.Persistencia
{
    public class ContextDb:DbContext
    {
        //creamos los dbset que se podrian interpretar como las tablas en la base de datos
        public DbSet<Mecanico> Mecanicos {get;set;}
        public DbSet<Vehiculo> Vehiculos {get;set;}
        public DbSet<Propietario> Propietarios {get;set;}
        public DbSet<Revision> Revisiones {get;set;}
        public DbSet<Ubicacion> Ubicaciones {get;set;}
        public DbSet<Repuesto> Repuestos {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if(!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer(@"Server=tcp:server-tallertic-g9.database.windows.net,1433;Initial Catalog=bd_tallertic;Persist Security Info=False;User ID=kkmadrid;Password=Realmadrid2022*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

    }
}