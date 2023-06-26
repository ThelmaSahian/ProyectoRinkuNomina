using Microsoft.AspNetCore.Mvc;
using RinkuNomina.Application.InputModels;
using RinkuNomina.Application.IServices;
using RinkuNomina.Application.Views;
using RinkuNominaDomain.Model;

namespace ProyectoRinkuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IRinkuNominaService _rinkuNominaService;
        public EmpleadosController(IRinkuNominaService rinkuNominaService)
        {
            _rinkuNominaService = rinkuNominaService;
        }

        // GET: EmpleadosController/GetAll
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Empleado>> GetAll()
        {
            List<Empleado> data = await _rinkuNominaService.GetAllEmpleados();
            return data;
        }

        // GET: EmpleadosController/GetComboEmpleados
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EmpleadoView>> GetComboEmpleados()
        {
            List<EmpleadoView> data = await _rinkuNominaService.GetComboEmpleados();
            return data;
        }

        // GET: EmpleadosController/CreateEmpleado
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int CreateEmpleado(EmpleadoInputModel inputModel)
        {
            return _rinkuNominaService.CreateEmpleado(inputModel);
        }
    }
}
