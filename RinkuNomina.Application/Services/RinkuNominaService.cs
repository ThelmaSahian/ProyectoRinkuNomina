using RinkuNomina.Application.InputModels;
using RinkuNomina.Application.IServices;
using RinkuNomina.Application.Views;
using RinkuNomina.Domain.IRepositories;
using RinkuNomina.Domain.Model;
using RinkuNominaDomain.Model;

namespace RinkuNomina.Application.Services
{
    public class RinkuNominaService : IRinkuNominaService
    {
        private readonly IRinkuNominaRepository _rinkuNominaRepository;

        public RinkuNominaService(IRinkuNominaRepository rinkuNominaRepository)
        {
            _rinkuNominaRepository = rinkuNominaRepository;
        }

        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Empleado>> GetAllEmpleados()
        {
            return await _rinkuNominaRepository.GetAllEmpleados();
        }

        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<IList<EmpleadoView>> GetComboEmpleados()
        {
            IList<Empleado> list = await _rinkuNominaRepository.GetAllEmpleados();
            return list.Select(empleado => new EmpleadoView(empleado)).ToList();
        }

        /// <summary>
        /// Servicio para obtener todos los roles y convertirlos en combo
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ComboView>> GetComboRoles()
        {
            IList<RolEmpleado> list = await _rinkuNominaRepository.GetComboRoles();
            return list.Select(rol => new ComboView(rol)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public int CreateEmpleado(EmpleadoInputModel inputModel)
        {
            IList<Empleado> list = _rinkuNominaRepository.GetAllEmpleados().Result;
            Empleado empleadoFind = list.FirstOrDefault(x => x.NumeroEmpleado == inputModel.NumeroEmpleado);
            if (empleadoFind != null)
            {
                return 1;
            }
            Empleado empleado = new()
            {
                Nombre = inputModel.Nombre,
                ApellidoPaterno = inputModel.ApellidoPaterno,
                ApellidoMaterno = inputModel.ApellidoMaterno,
                NumeroEmpleado = inputModel.NumeroEmpleado,
                IdRol = inputModel.IdRol,
            };
            bool result = _rinkuNominaRepository.CreateEmpleado(empleado);
            if (result)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }

        public int CreateEntregasEmpleado(EntregasEmpleadoInputModel inputModel)
        {
            IList<EntregasPorEmpleado> list = _rinkuNominaRepository.GetAllEntregasEmpleados().Result;
            EntregasPorEmpleado empleadoFind = list.FirstOrDefault(x => x.IdEmpleado == inputModel.IdEmpleado);
            if (empleadoFind != null)
            {
                return 1;
            }
            EntregasPorEmpleado empleado = new()
            {
                IdEmpleado = inputModel.IdEmpleado,
                FechaEntrega = inputModel.FechaEntrega,
                CantidadEntregas = inputModel.CantidadEntregas,
            };
            bool result = _rinkuNominaRepository.CreateEntregasEmpleado(empleado);
            if (result)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }
    }
}