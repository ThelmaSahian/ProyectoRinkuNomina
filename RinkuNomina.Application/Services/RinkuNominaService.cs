using RinkuNomina.Application.InputModels;
using RinkuNomina.Application.IServices;
using RinkuNomina.Application.Views;
using RinkuNomina.Domain.IRepositories;
using RinkuNomina.Domain.Model;
using RinkuNominaDomain.Model;
using System.Data;

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
        public async Task<List<Empleado>> GetAllEmpleados()
        {
            return await _rinkuNominaRepository.GetAllEmpleados();
        }

        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmpleadoView>> GetComboEmpleados()
        {
            List<Empleado> list = await _rinkuNominaRepository.GetAllEmpleados();
            return list.Select(empleado => new EmpleadoView(empleado)).ToList();
        }

        /// <summary>
        /// Servicio para obtener todos los roles y convertirlos en combo
        /// </summary>
        /// <returns></returns>
        public async Task<List<ComboView>> GetComboRoles()
        {
            List<RolEmpleado> list = await _rinkuNominaRepository.GetComboRoles();
            return list.Select(rol => new ComboView(rol)).ToList();
        }

        /// <summary>
        /// Servicio para crear un empleado
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public int CreateEmpleado(EmpleadoInputModel inputModel)
        {
            List<Empleado> list = _rinkuNominaRepository.GetAllEmpleados().Result;
            Empleado? empleadoFind = list.FirstOrDefault(x => x.NumeroEmpleado == inputModel.NumeroEmpleado);
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

        /// <summary>
        /// Servicio para crear las entregas/movimientos por empleado
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public int CreateEntregasEmpleado(EntregasEmpleadoInputModel inputModel)
        {
            List<EntregasPorEmpleado> list = _rinkuNominaRepository.GetAllEntregasEmpleados().Result;
            EntregasPorEmpleado? empleadoFind = list.FirstOrDefault(x => x.IdEmpleado == inputModel.IdEmpleado);
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

        /// <summary>
        /// Servicio para consultar las entregas/movimientos por empleado
        /// </summary>
        /// <returns></returns>
        public List<EntregasEmpleadoView> GetEntregasEmpleadosSP()
        {
            List<EntregasEmpleadoView> entregasEmpleadoViews = new();
            DataTable dataTable = _rinkuNominaRepository.GetEntregasEmpleadosSP();
            foreach (DataRow row in dataTable.Rows)
            {
                string? idEntregaStr = row.Field<string?>("IdEntrega") ?? null;
                string? numeroEmpleadoStr = row.Field<string?>("NumeroEmpleado") ?? null;
                string? nombre = row.Field<string>("Nombre");
                string? rol = row.Field<string>("Rol");
                string? mes = row.Field<string>("Mes");
                string cantidadEntregasStr = row.Field<string>("CantidadEntregas") ?? "";
                string? pagoTotalBonosStr = row.Field<string>("PagoTotalBonos");
                string? retencionesStr = row.Field<string>("Retenciones");
                string? valesStr = row.Field<string>("Vales");
                string? sueldoTotalStr = row.Field<string>("SueldoTotal");
                string? horasTrabajadasStr = row.Field<string>("horasTrabajadas");

                Guid? idEntrega = idEntregaStr != null ? new Guid(idEntregaStr) : null;
                int? numeroEmpleado = numeroEmpleadoStr != null ? int.Parse(numeroEmpleadoStr) : null;
                decimal? cantidadEntregas = cantidadEntregasStr != null ? decimal.Parse(cantidadEntregasStr) : null;
                decimal? horasTrabajadas = horasTrabajadasStr != null ? decimal.Parse(horasTrabajadasStr) : null;
                decimal? pagoTotalBonos = pagoTotalBonosStr != null ? decimal.Parse(pagoTotalBonosStr) : null;
                decimal? retenciones = retencionesStr != null ? decimal.Parse(retencionesStr) : null;
                decimal? vales = valesStr != null ? decimal.Parse(valesStr) : null;
                decimal? sueldoTotal = sueldoTotalStr != null ? decimal.Parse(sueldoTotalStr) : null;

                entregasEmpleadoViews.Add(
                    new EntregasEmpleadoView(
                        idEntrega, numeroEmpleado, nombre, rol, mes, cantidadEntregas
                        , horasTrabajadas, pagoTotalBonos, retenciones, vales, sueldoTotal));
            }
            return entregasEmpleadoViews;
        }
    }
}