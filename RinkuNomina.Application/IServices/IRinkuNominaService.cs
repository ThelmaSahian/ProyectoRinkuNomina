using RinkuNomina.Application.InputModels;
using RinkuNomina.Application.Views;
using RinkuNominaDomain.Model;

namespace RinkuNomina.Application.IServices
{
    public interface IRinkuNominaService
    {
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        Task<List<Empleado>> GetAllEmpleados();

        /// <summary>
        /// Servicio para obtener todos los empleados y convertirlos en combo
        /// </summary>
        /// <returns></returns>
        Task<List<EmpleadoView>> GetComboEmpleados();

        /// <summary>
        /// Servicio para obtener todos los roles y convertirlos en combo
        /// </summary>
        /// <returns></returns>
        Task<List<ComboView>> GetComboRoles();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        int CreateEmpleado(EmpleadoInputModel inputModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        int CreateEntregasEmpleado(EntregasEmpleadoInputModel inputModel);

        /// <summary>
        /// Servicio para consultar las entregas/movimientos por empleado
        /// </summary>
        /// <returns></returns>
        List<EntregasEmpleadoView> GetEntregasEmpleadosSP();
    }
}
