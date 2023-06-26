using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RinkuNomina.Application;
using RinkuNomina.Domain.IRepositories;
using RinkuNomina.Domain.Model;
using RinkuNominaDomain.Model;
using System.Data;

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
        public async Task<List<Empleado>> GetAllEmpleados()
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
        /// Servicio para obtener todos los roles de empleados
        /// </summary>
        /// <returns></returns>
        public async Task<List<RolEmpleado>> GetComboRoles()
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
        /// Servicio para crear un empleado
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

        /// <summary>
        /// Servicio para obtener todas las entregas por empleado
        /// </summary>
        /// <returns></returns>
        public async Task<List<EntregasPorEmpleado>> GetAllEntregasEmpleados()
        {
            try
            {
                return await _context.Set<EntregasPorEmpleado>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        /// <summary>
        /// Servicio para crear las entregas/movimientos por empleado
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public bool CreateEntregasEmpleado(EntregasPorEmpleado inputModel)
        {
            try
            {
                var idEmpleadoParameter = new SqlParameter("@IdEmpleado", inputModel.IdEmpleado);
                var fechaEntregaParameter = new SqlParameter("@FechaEntrega", inputModel.FechaEntrega);
                var cantidadEntregasParameter = new SqlParameter("@CantidadEntregas", inputModel.CantidadEntregas);

                var result = _context.Database
                    .ExecuteSqlRaw("dbo.CreateEntregasEmpleado @IdEmpleado, @FechaEntrega, @CantidadEntregas ", idEmpleadoParameter, fechaEntregaParameter, cantidadEntregasParameter);
                return result < 0;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        /// <summary>
        /// Servicio para consultar las entregas/movimientos por empleado
        /// </summary>
        /// <returns></returns>
        public DataTable GetEntregasEmpleadosSP()
        {
            DataTable dataTable = new("EntregasEmpleados");
            string? connection = _context.Database.GetConnectionString();
            //string? command = "dbo.GetEntregasEmpleados";
            //FormattableString formattableString = $"{command}";
            //var result = _context.Database.SqlQuery<dynamic>(formattableString);

            SqlConnection sqlConnection = new(connection);
            sqlConnection.Open();
            try
            {
                using (SqlCommand cmd = new("dbo.GetEntregasEmpleados", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using SqlDataReader reader = cmd.ExecuteReader();
                    dataTable.Clear();
                    DataColumn[] columns = new DataColumn[] {
                        new DataColumn("IdEntrega")
                        , new DataColumn("NumeroEmpleado")
                        , new DataColumn("Nombre")
                        , new DataColumn("Rol")
                        , new DataColumn("Mes")
                        , new DataColumn("CantidadEntregas")
                        , new DataColumn("HorasTrabajadas")
                        , new DataColumn("PagoTotalBonos")
                        , new DataColumn("Retenciones")
                        , new DataColumn("Vales")
                        , new DataColumn("SueldoTotal")
                    };
                    dataTable.Columns.AddRange(columns);

                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["IdEntrega"] = reader["IdEntrega"];
                        row["NumeroEmpleado"] = reader["NumeroEmpleado"];
                        row["Nombre"] = reader["Nombre"];
                        row["Rol"] = reader["Rol"];
                        row["Mes"] = reader["Mes"];
                        row["CantidadEntregas"] = reader["CantidadEntregas"];
                        row["HorasTrabajadas"] = reader["HorasTrabajadas"];
                        row["PagoTotalBonos"] = reader["PagoTotalBonos"];
                        row["Retenciones"] = reader["Retenciones"];
                        row["Vales"] = reader["Vales"];
                        row["SueldoTotal"] = reader["SueldoTotal"];
                        dataTable.Rows.Add(row);

                    }
                }
                sqlConnection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                throw new(ex.Message);
            }
        }
    }
}
