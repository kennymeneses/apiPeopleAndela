using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApiAndela.Manager;

namespace PeopleApiAndela.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleManager _manager;

        public PeopleController(IPeopleManager manager)
        {
            _manager = manager;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                //var clientes = await _manejadorClientes.ObtenerClientes();

                var peoples = await _manager.GetAllPeople();

                return Ok(peoples);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetSpecifiedProfile(int personId)
        {
            try
            {
                //var clientes = await _manejadorOrdenes.ObtenerHistoricoClienteMesActual(dni);
                var profile = await _manager.GetSpecifiedPeople(personId);

                return Ok(profile);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
