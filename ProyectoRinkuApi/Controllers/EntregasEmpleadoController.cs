using Microsoft.AspNetCore.Mvc;
using RinkuNomina.Application.InputModels;
using RinkuNomina.Application.IServices;
using RinkuNomina.Application.Views;

namespace ProyectoRinkuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EntregasEmpleadoController : ControllerBase
    {
        private IRinkuNominaService _rinkuNominaService;
        public EntregasEmpleadoController(IRinkuNominaService rinkuNominaService)
        {
            _rinkuNominaService = rinkuNominaService;
        }

        // POST: EmpleadosController/CreateEmpleado
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int CreateEntregasEmpleado(EntregasEmpleadoInputModel inputModel)
        {
            return _rinkuNominaService.CreateEntregasEmpleado(inputModel);
        }

        // GET: EmpleadosController/GetEntregasEmpleadosSP
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EntregasEmpleadoView> GetEntregasEmpleadosSP()
        {
            return _rinkuNominaService.GetEntregasEmpleadosSP();
        }
    }
}
