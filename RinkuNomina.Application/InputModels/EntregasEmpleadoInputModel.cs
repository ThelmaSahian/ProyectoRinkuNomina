namespace RinkuNomina.Application.InputModels
{
    public class EntregasEmpleadoInputModel
    {
        public Guid IdEmpleado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal CantidadEntregas { get; set; }
    }
}
