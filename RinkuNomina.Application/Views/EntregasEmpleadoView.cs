namespace RinkuNomina.Application.Views
{
    public class EntregasEmpleadoView
    {
        public Guid? IdEntrega { get; set; }
        public int? NumeroEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Rol { get; set; }
        public string? Mes { get; set; }
        public decimal? CantidadEntregas { get; set; }
        public decimal? HorasTrabajadas { get; set; }
        public decimal? PagoTotalBonos { get; set; }
        public decimal? Retenciones { get; set; }
        public decimal? Vales { get; set; }
        public decimal? SueldoTotal { get; set; }

        public EntregasEmpleadoView(Guid? idEntrega, int? numeroEmpleado, string? nombre, string? rol, string? mes, decimal? cantidadEntregas, decimal? horasTrabajadas, decimal? pagoTotalBonos, decimal? retenciones, decimal? vales, decimal? sueldoTotal)
        {
            IdEntrega = idEntrega;
            NumeroEmpleado = numeroEmpleado;
            Nombre = nombre;
            Rol = rol;
            Mes = mes;
            CantidadEntregas = cantidadEntregas;
            HorasTrabajadas = horasTrabajadas;
            PagoTotalBonos = pagoTotalBonos;
            Retenciones = retenciones;
            Vales = vales;
            SueldoTotal = sueldoTotal;
        }
    }
}
