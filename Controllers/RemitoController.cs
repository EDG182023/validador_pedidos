using Microsoft.AspNetCore.Mvc;
using ValidadorPedidos.Services;

namespace ValidadorPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemitoController : ControllerBase
    {
        private readonly ExcelService _excelService;

        public RemitoController(ExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("cargar")]
        public IActionResult Cargar(IFormFile archivo)
        {
            if (archivo == null) return BadRequest();

            var ruta = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(ruta))
            {
                archivo.CopyTo(stream);
            }

            var pedidos = _excelService.LeerPedidos(ruta);
            return Ok(pedidos);
        }
    }
}
