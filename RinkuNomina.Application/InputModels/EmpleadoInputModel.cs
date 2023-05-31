namespace RinkuNomina.Application.InputModels
{
    public class EmpleadoInputModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public int NumeroEmpleado { get; set; }
        public Guid IdRol { get; set; }
    }
}
