using System;
using Taller.App.Persistencia;
using Taller.App.Dominio;

namespace Taller.App.Consola
{

    class Program
    {
        private static RepositorioMecanico repositorio=new RepositorioMecanico(new Persistencia.ContextDb());
        private static RepositorioVehiculo repositoriov=new RepositorioVehiculo(new Persistencia.ContextDb());
        private static RepositorioPropietario repositoriop=new RepositorioPropietario(new Persistencia.ContextDb());
        private static RepositorioRepuesto repositorior=new RepositorioRepuesto(new Persistencia.ContextDb());
        private static RepositorioUbicacion repositorioub=new RepositorioUbicacion(new Persistencia.ContextDb());
        private static RepositorioRevision repositoriorev=new RepositorioRevision(new Persistencia.ContextDb());


        static void Main(string[] arg)
        {
            //metodos mecanicos
            //AgregarMecanico();
            //ObtenerMecanicos();
            //BuscarMecanico("2");
            //EditarMecanico();
            //EliminarMecanico("2");

            //metodos propietarios
            //AgregarPropietario();
             //ObtenerPropietarios();
             //BuscarPropietario("2");
             EditarPropietario();
             //EliminarPropietario("2");
            
            //metodos vehicullos
            //AgregarVehiculo();
            //ObtenerVehiculos();
            //BuscarVehiculo("vxg-123");
            //EliminarVehiculo("vxg-123");
            //EditarVehiculo();

            //metodos repuestos
            //AgregarRepuesto();
            //ObtenerRepuestos();
            //BuscarRepuesto("1");
            //EliminarRepuesto("1");
            //EditarRepuesto();
        
            //metodorevision
            //AgregarRevision();
            //ObtenerRevisiones();
            //BuscarRevision("1");
            //BuscarRevisionP("vxg-125");
            //EliminarRevision("1");
            //EditarRevision();

        }

        //creamos los metodos para la accion agregar
        //para agregar mecanicos

        static void AgregarMecanico()
        {
            var mecanico =new Mecanico
            {
               
                MecanicoId="1077861911",
                nombre="ricardi rodriguez",
                telefono="3105890230",
                fechaNacimiento="1992-10-10",
                contrasenia="12445",
                direccion="calle 8",
                nivelEstudio="bachiller",
                

            };

            repositorio.AgregarMecanico(mecanico);
        }

//para crear propietarios
        static void AgregarPropietario()
        {
            var propietario =new Propietario
            {
               
                PropietarioId="1077861912",
                nombre="camilo ordoñez",
                telefono="3135890230",
                fechaNacimiento="1991-10-09",
                contrasenia="12445",
                ciudad="Neiva",
                correo="kkmadrid@hotmail.com",
            };

            repositoriop.AgregarPropietario(propietario);
        }

//para crear vehiculos
        static void AgregarVehiculo()
        {
            var vehiculo=new Vehiculo
            {
            VehiculoId="1",
            PlacaVehiculo="vxg-125",
            PropietarioVehiculo="1077861912",
            MarcaVehiculo="BMW",
            LineaVehiculo="linea 1",
            ModeloVehiculo ="2000",
            ColorVehiculo ="blanco",
            MotorVehiculo ="mts2600rp",
            ChasisVehiculo ="sadkjk45a",
            CapacidadVehiculo ="2",
            CilindrajeVehiculo ="1600",
            TipoVehiculo="Automovil",
            CiudadVehiculo="Tokio",
            CaracteristicasVehiculo="con aire acondicionado", 

            };
            repositoriov.AgregarVehiculo(vehiculo);
        }
//para crear repuestos

static void AgregarRepuesto()
{
    var repuesto =new Repuesto{
    RepuestoId="1",
    descripcion="Filtro de Aire",
    cantidad="100",
    precio="$180.000",
    };
    repositorior.AgregarRepuesto(repuesto);

}

//para crear sedes Ubicaciones

static void AgregarUbicacion()
{
    var ubicacion=new Ubicacion
    {
        UbicacionId="1",
        UbicacionDescripcion="Neiva",
    };
    repositorioub.AgregarUbicacion(ubicacion);
}

//para agregar revisiones
static void AgregarRevision()
{
    var revision=new Revision
    {
        RevisionId="1",
        fecharevision="1991-09-10",
        hora="23:00",
        MecanicoId="1077861911",
        PlacaVehiculo="vxg-125",
        SedeRevision="neiva",
        DetalleRevision="sin novedades respecto a la revision",
        EstadoRevision="Revision",
    };
    repositoriorev.AgregarRevision(revision);

}
    

//metodos para consultar en general
//obtener mecanicos
        static void ObtenerMecanicos()
        {
             foreach (var m in repositorio.ObtenerMecanicos())
             {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Nombre: "+m.nombre+"\nTelefono: "+m.telefono+"\nFecha Nacimiento: "+m.fechaNacimiento+ "\nContra: "+m.contrasenia);
                Console.WriteLine("----------------------------");

             }
        }

//obtener propietarios
static void ObtenerPropietarios()
        {
             foreach (var m in repositoriop.ObtenerPropietarios())
             {
                
                Console.WriteLine("----------------------------");
                Console.WriteLine("Nombre: "+m.nombre+"\nTelefono: "+m.telefono+"\nFecha Nacimiento: "+m.fechaNacimiento+ "\nContra: "+m.contrasenia+"\nCiudad: "+m.ciudad+"\nCorreo: "+m.correo);
                Console.WriteLine("----------------------------");

             }
        }
//obtener vehiculos
static void ObtenerVehiculos()
        {
             foreach (var m in repositoriov.ObtenerVehiculos())
             {
                
                Console.WriteLine("----------------------------");
                Console.WriteLine("\nPlaca Vehículo: "+m.PlacaVehiculo+"\nPropietario Id: "+m.PropietarioVehiculo+ "\nMarca: "+m.MarcaVehiculo+"\nLinea: "+m.LineaVehiculo+"\nModelo: "+m.ModeloVehiculo);
                Console.WriteLine("----------------------------");

             }
        }

// obtener repuestos

static void ObtenerRepuestos()
{
    foreach (var m in repositorior.ObtenerRepuestos())
             {
                
                Console.WriteLine("----------------------------");
                Console.WriteLine("\nId Repuesto: "+m.RepuestoId+"\nDescripcion: "+m.descripcion+ "\nCantidad: "+m.cantidad+"\nPrecio: "+m.precio);
                Console.WriteLine("----------------------------");

             }
}


//obtener sedes

static void ObtenerUbicaciones()
{
    foreach (var m in repositorioub.ObtenerUbicaciones())
             {
                
                Console.WriteLine("----------------------------");
                Console.WriteLine("\nId Sede: "+m.UbicacionId+"\nCiudad: "+m.UbicacionDescripcion);
                Console.WriteLine("----------------------------");

             }

}

//obtener revisiones
static void ObtenerRevisiones()
{
    foreach (var m in repositoriorev.ObtenerRevisiones())
             {
                
                Console.WriteLine("----------------------------");
                Console.WriteLine("\nId Sede: "+m.RevisionId+"\nCiudad: "+m.fecharevision+"\nHora: "+m.hora+"\nMecánico Encargado: "+m.MecanicoId+"\nVehículo: "+m.PlacaVehiculo);
                Console.WriteLine("----------------------------");

             }

}

//metodos para consulta en especifico
//para mecanicos
        static void BuscarMecanico(string id)
        {
            var m=repositorio.BuscarMecanico(id);
            if(m!=null)
            {
                Console.WriteLine("Registro encontrado; "+m.nombre);
            }else
            {
                Console.WriteLine("Registro no encontrado");

            }


        }
//para propietarios
        static void BuscarPropietario(string id)
        {
            var m=repositoriop.BuscarPropietario(id);
            if(m!=null)
            {
                Console.WriteLine("Registro encontrado; "+m.nombre);
            }else
            {
                Console.WriteLine("Registro no encontrado");

            }


        }
//para buscar vehiculos
     static void BuscarVehiculo(string placa)
        {
            var m=repositoriov.BuscarVehiculo(placa);
            if(m!=null)
            {
                Console.WriteLine("Registro encontrado; "+"\nPlaca:"+m.PlacaVehiculo+"\nMarca:"+m.MarcaVehiculo);
            }else
            {
                Console.WriteLine("Registro no encontrado");

            }


        }

// para busca repuestos

        static void BuscarRepuesto(string id)
        {
            var m=repositorior.BuscarRepuesto(id);
            if(m!=null)
            {
                Console.WriteLine("Registro encontrado; "+"\nId Repuesto:"+m.RepuestoId+"\nDescripción:"+m.descripcion);
            }else
            {
                Console.WriteLine("Registro no encontrado");

            }


        }

          static void BuscarRevision(string id)
        {
            var m=repositoriorev.BuscarRevision(id);
            if(m!=null)
            {
                Console.WriteLine("Registro encontrado; "+"\nId:"+m.RevisionId+"\nVehículo:"+m.PlacaVehiculo+"\nVehículo:"+m.fecharevision);
            }else
            {
                Console.WriteLine("Registro no encontrado");

            }


        }

        static void BuscarRevisionP(string placa)
        {
            var m=repositoriorev.BuscarRevisionP(placa);
            if(m!=null)
            {
                Console.WriteLine("Registro encontrado; "+"\nId:"+m.RevisionId+"\nVehículo:"+m.PlacaVehiculo+"\nFecha:"+m.fecharevision);
            }else
            {
                Console.WriteLine("Registro no encontrado");

            }


        }


        //creamos el metodo eliminar
        
        //para eliminar mecanicos
        static void EliminarMecanico(string id){
            repositorio.EliminarMecanico(id);
        }

        //para eliminar propietarios
        static void EliminarPropietario(string id)
        {
            repositoriop.EliminarPropietario(id);
        }

        //para eliminar vehiculo
        static void EliminarVehiculo(string placa)
        {
            repositoriov.EliminarVehiculo(placa);
        }

        //para eliminar repuestos
        static void EliminarRepuesto(string id)
        {
            repositorior.EliminarRepuesto(id);
        }

        //para eliminar revisiones
        static void EliminarRevision(string id)
        {
            repositoriorev.EliminarRevision(id);
        }

//para eliminar sedes ubicaciones
         static void EliminarUbicacion(string id)
        {
            repositorioub.EliminarUbicacion(id);
        }


        //creamos el metodo de editar mecanico

        static void EditarMecanico(){
            var mecanico =new Mecanico
            {
               
                MecanicoId="1077861911",
                nombre="ricardi rodriguez 1",
                telefono="3135890231",
                fechaNacimiento="789",
                contrasenia="1244567",
                direccion="calle 9",
                nivelEstudio="Profesional",
            };

            repositorio.EditarMecanico(mecanico);


        }

        static void EditarPropietario()
        {
            var propietario=new Propietario
            {
                PropietarioId="1077861912",
                nombre="camilo ordoñez 1",
                telefono="3135890231",
                fechaNacimiento="1991-10-09",
                contrasenia="12445",
                ciudad="Bogota",
                correo="kkmadrid1@hotmail.com",

            };

            repositoriop.EditarPropietario(propietario);
        }

        static void EditarRepuesto()
        {
            var repuesto=new Repuesto
            {
                RepuestoId="1",
                descripcion="Filtro de Aire 1",
                cantidad="101",
                precio="$181.000",

            };
            repositorior.EditarRepuesto(repuesto);
        }

        static void EditarVehiculo()
        {
            var vehiculo=new Vehiculo
            {
            VehiculoId="1",
            PlacaVehiculo="vxg-125",
            PropietarioVehiculo="1077861912",
            MarcaVehiculo="BMW",
            LineaVehiculo="linea 1",
            ModeloVehiculo ="2001",
            ColorVehiculo ="negro 1",
            MotorVehiculo ="mts2600rp",
            ChasisVehiculo ="sadkjk45a",
            CapacidadVehiculo ="4",
            CilindrajeVehiculo ="1400",
            TipoVehiculo="automovil",
            CiudadVehiculo="Tokio",
            CaracteristicasVehiculo="con aire acondicionado 1", 

            };
            repositoriov.EditarVehiculo(vehiculo);
        }

        static void EditarRevision()
        {
            var revision=new Revision
            {
                RevisionId="1",
                fecharevision="1991-09-10",
                hora="23:31",
                MecanicoId="1077861911",
                PlacaVehiculo="vxg-125",
                SedeRevision="Neiva",
                DetalleRevision="novedad 1",
                EstadoRevision="Revision",
            };
            repositoriorev.EditarRevision(revision);
        }

    }
}