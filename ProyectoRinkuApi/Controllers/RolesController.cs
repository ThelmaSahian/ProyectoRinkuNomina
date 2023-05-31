using Microsoft.AspNetCore.Mvc;
using RinkuNomina.Application.IServices;
using RinkuNomina.Application.Views;

namespace ProyectoRinkuApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : Controller
    {
        private IRinkuNominaService _rinkuNominaService;

        public RolesController(IRinkuNominaService rinkuNominaService)
        {
            _rinkuNominaService = rinkuNominaService;
        }

        // GET: RolesController/GetCombo
        /// <summary>
        /// Servicio para obtener todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ComboView>> GetCombo()
        {
            IList<ComboView> data = await _rinkuNominaService.GetComboRoles();
            return data;
        }
    }
}
