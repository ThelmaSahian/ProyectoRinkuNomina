using RinkuNomina.Domain.Model;
using RinkuNominaDomain.Model;

namespace RinkuNomina.Domain.IRepositories
{
    public interface IRinkuNominaRepository
    {
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        Task<IList<Empleado>> GetAllEmpleados();

        /// <summary>
        /// Servicio para obtener todos los roles y convertirlos en combo
        /// </summary>
        /// <returns></returns>

        Task<IList<RolEmpleado>> GetComboRoles();

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
        Task<IList<EntregasPorEmpleado>> GetAllEntregasEmpleados();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        bool CreateEntregasEmpleado(EntregasPorEmpleado inputModel);
    }
}
