using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinkuNomina.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNumeroEmpleadotablaEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroEmpleado",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroEmpleado",
                table: "Empleado");
        }
    }
}
