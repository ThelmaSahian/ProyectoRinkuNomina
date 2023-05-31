using System.Numerics;

namespace RinkuNominaDomain.Common
{
    public interface IEmpleados
    {
        BigInteger IdEmpleado { get; set; }

        int IdRol { get; set; }
        string Nombre { get; set; }
        string ApellidoPaterno { get; set; }
        string ApellidoMaterno { get; set; }

    }
}
