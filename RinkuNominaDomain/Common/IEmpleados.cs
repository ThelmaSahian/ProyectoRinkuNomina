namespace RinkuNominaDomain.Common
{
    public interface IEmpleados
    {
        Guid IdEmpleado { get; set; }

        Guid IdRol { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }
        public int NumeroEmpleado { get; set; }


    }
}
