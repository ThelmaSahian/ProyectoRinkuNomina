using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RinkuNomina.Application;
using RinkuNomina.Domain.IRepositories;
using RinkuNomina.Domain.Model;
using RinkuNominaDomain.Model;

namespace RinkuNomina.Infrastructure.Repositories
{
    public class RinkuNominaRepository : IRinkuNominaRepository
    {
        private readonly RinkuContext _context;
        public RinkuNominaRepository(RinkuContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Empleado>> GetAllEmpleados()
        {
            try
            {
                return await _context.Set<Empleado>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        public async Task<IList<RolEmpleado>> GetComboRoles()
        {
            try
            {
                return await _context.Set<RolEmpleado>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public bool CreateEmpleado(Empleado inputModel)
        {
            try
            {
                var nombreParameter = new SqlParameter("@Nombre", inputModel.Nombre);
                var apellidoPaternoParameter = new SqlParameter("@ApellidoPaterno", inputModel.ApellidoPaterno);
                var apellidoMaternoParameter = new SqlParameter("@ApellidoMaterno", inputModel.ApellidoMaterno);
                var numeroEmpleadoParameter = new SqlParameter("@NumeroEmpleado", inputModel.NumeroEmpleado);
                var idRolParameter = new SqlParameter("@IdRol", inputModel.IdRol);

                var result = _context.Database
                    .ExecuteSqlRaw("dbo.CreateEmpleado @Nombre, @ApellidoPaterno, @ApellidoMaterno, @NumeroEmpleado, @IdRol", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, numeroEmpleadoParameter, idRolParameter);
                return result < 0;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}
