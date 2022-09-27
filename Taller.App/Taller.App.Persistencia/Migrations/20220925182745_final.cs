using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller.App.Persistencia.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mecanicos",
                columns: table => new
                {
                    MecanicoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nivelEstudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanicos", x => x.MecanicoId);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    PropietarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.PropietarioId);
                });

            migrationBuilder.CreateTable(
                name: "Repuestos",
                columns: table => new
                {
                    RepuestoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuestos", x => x.RepuestoId);
                });

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    UbicacionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UbicacionDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.UbicacionId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropietarioVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModeloVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotorVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChasisVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CilindrajeVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaracteristicasVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Revisiones",
                columns: table => new
                {
                    RevisionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fecharevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MecanicoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehiculoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SedeRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetalleRevision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRevision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisiones", x => x.RevisionId);
                    table.ForeignKey(
                        name: "FK_Revisiones_Mecanicos_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mecanicos",
                        principalColumn: "MecanicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revisiones_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "VehiculoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_MecanicoId",
                table: "Revisiones",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_VehiculoId",
                table: "Revisiones",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "Repuestos");

            migrationBuilder.DropTable(
                name: "Revisiones");

            migrationBuilder.DropTable(
                name: "Ubicaciones");

            migrationBuilder.DropTable(
                name: "Mecanicos");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
