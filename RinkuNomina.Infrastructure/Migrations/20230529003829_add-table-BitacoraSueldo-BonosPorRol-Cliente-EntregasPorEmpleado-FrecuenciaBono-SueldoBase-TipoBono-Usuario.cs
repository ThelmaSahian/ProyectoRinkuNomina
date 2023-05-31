using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinkuNomina.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtableBitacoraSueldoBonosPorRolClienteEntregasPorEmpleadoFrecuenciaBonoSueldoBaseTipoBonoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuarioCreacion",
                table: "RolEmpleado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioModificacion",
                table: "RolEmpleado");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioCreacion",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioModificacion",
                table: "Empleado");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "RolEmpleado",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuarioCreacion2",
                table: "RolEmpleado",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuarioModificacion2",
                table: "RolEmpleado",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdRol2",
                table: "Empleado",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuarioCreacion2",
                table: "Empleado",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuarioModificacion2",
                table: "Empleado",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BitacoraSueldo",
                columns: table => new
                {
                    IdBitacoraSueldo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraSueldo", x => x.IdBitacoraSueldo);
                });

            migrationBuilder.CreateTable(
                name: "BonosPorRol",
                columns: table => new
                {
                    IdBonoRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRol = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoBono = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdFrecuenciaBono = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonosPorRol", x => x.IdBonoRol);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "EntregasPorEmpleado",
                columns: table => new
                {
                    IdEntrega = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClienteEntrega = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregasPorEmpleado", x => x.IdEntrega);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaBono",
                columns: table => new
                {
                    IdFrecuenciaBono = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrecuenciaBono", x => x.IdFrecuenciaBono);
                });

            migrationBuilder.CreateTable(
                name: "SueldoBase",
                columns: table => new
                {
                    IdSueldoBase = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmpleado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CantidadPorHora = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SueldoBase", x => x.IdSueldoBase);
                });

            migrationBuilder.CreateTable(
                name: "TipoBono",
                columns: table => new
                {
                    IdTipoBono = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBono", x => x.IdTipoBono);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCreacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUsuarioModificacion = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitacoraSueldo");

            migrationBuilder.DropTable(
                name: "BonosPorRol");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EntregasPorEmpleado");

            migrationBuilder.DropTable(
                name: "FrecuenciaBono");

            migrationBuilder.DropTable(
                name: "SueldoBase");

            migrationBuilder.DropTable(
                name: "TipoBono");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdUsuarioCreacion2",
                table: "RolEmpleado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioModificacion2",
                table: "RolEmpleado");

            migrationBuilder.DropColumn(
                name: "IdRol2",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioCreacion2",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "IdUsuarioModificacion2",
                table: "Empleado");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "RolEmpleado",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioCreacion",
                table: "RolEmpleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioModificacion",
                table: "RolEmpleado",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioCreacion",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioModificacion",
                table: "Empleado",
                type: "int",
                nullable: true);
        }
    }
}
