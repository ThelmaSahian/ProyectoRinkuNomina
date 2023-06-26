using RinkuNomina.Domain.Model;
using RinkuNominaDomain.Model;
using System.Data;

namespace RinkuNomina.Domain.IRepositories
{
    public interface IRinkuNominaRepository
    {
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        Task<List<Empleado>> GetAllEmpleados();

        /// <summary>
        /// Servicio para obtener todos los roles y convertirlos en combo
        /// </summary>
        /// <returns></returns>

        Task<List<RolEmpleado>> GetComboRoles();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>

        bool CreateEmpleado(Empleado inputModel);

        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        Task<List<EntregasPorEmpleado>> GetAllEntregasEmpleados();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        bool CreateEntregasEmpleado(EntregasPorEmpleado inputModel);

        /// <summary>
        /// Servicio para consultar las entregas/movimientos por empleado
        /// </summary>
        /// <returns></returns>
        DataTable GetEntregasEmpleadosSP();
    }
}
