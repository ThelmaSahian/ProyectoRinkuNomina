using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinkuNomina.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatefieldsbitacora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUsuarioModificacion2",
                table: "RolEmpleado",
                newName: "IdUsuarioModificacion");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioCreacion2",
                table: "RolEmpleado",
                newName: "IdUsuarioCreacion");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioModificacion2",
                table: "Empleado",
                newName: "IdUsuarioModificacion");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioCreacion2",
                table: "Empleado",
                newName: "IdUsuarioCreacion");

            migrationBuilder.RenameColumn(
                name: "IdRol2",
                table: "Empleado",
                newName: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUsuarioModificacion",
                table: "RolEmpleado",
                newName: "IdUsuarioModificacion2");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioCreacion",
                table: "RolEmpleado",
                newName: "IdUsuarioCreacion2");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioModificacion",
                table: "Empleado",
                newName: "IdUsuarioModificacion2");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioCreacion",
                table: "Empleado",
                newName: "IdUsuarioCreacion2");

            migrationBuilder.RenameColumn(
                name: "IdRol",
                table: "Empleado",
                newName: "IdRol2");
        }
    }
}
