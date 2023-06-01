using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinkuNomina.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldsBitacoraSueldo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "BitacoraSueldo",
                newName: "Vales");

            migrationBuilder.AddColumn<int>(
                name: "HorasTrabajadas",
                table: "BitacoraSueldo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PagoTotalBonos",
                table: "BitacoraSueldo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Retencion",
                table: "BitacoraSueldo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SueldoTotal",
                table: "BitacoraSueldo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasTrabajadas",
                table: "BitacoraSueldo");

            migrationBuilder.DropColumn(
                name: "PagoTotalBonos",
                table: "BitacoraSueldo");

            migrationBuilder.DropColumn(
                name: "Retencion",
                table: "BitacoraSueldo");

            migrationBuilder.DropColumn(
                name: "SueldoTotal",
                table: "BitacoraSueldo");

            migrationBuilder.RenameColumn(
                name: "Vales",
                table: "BitacoraSueldo",
                newName: "Total");
        }
    }
}
