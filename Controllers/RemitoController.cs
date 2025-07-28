using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ValidadorPedidos.Models;
using ValidadorPedidos.Services;

namespace ValidadorPedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemitoController : ControllerBase
    {
        private readonly SaadisDbService _saadisDbService;

        public RemitoController(SaadisDbService saadisDbService)
        {
            _saadisDbService = saadisDbService;
        }

        /// <summary>
        /// Inserta el pedido en la base de datos SAADIS si corresponde.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoSaadisDto pedido)
        {
            if (pedido == null)
                return BadRequest();

            await _saadisDbService.InsertRechrdeAsync(pedido);
            return Ok();
        }
    }
}
