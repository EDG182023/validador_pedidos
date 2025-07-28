using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ValidadorPedidos.Services;

namespace ValidadorPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemitoController : ControllerBase
    {
        private readonly ExcelService _excelService;
        private readonly ValidacionService _validacionService;
        private readonly StockApiService _stockService;

        public RemitoController(
            ExcelService excelService,
            ValidacionService validacionService,
            StockApiService stockService)
        {
            _excelService = excelService;
            _validacionService = validacionService;
            _stockService = stockService;
        }

        [HttpPost("cargar")]
        public async Task<IActionResult> Cargar(IFormFile archivo)
        {
            if (archivo == null) return BadRequest();

            var ruta = Path.GetTempFileName();
            using (var stream = System.IO.File.Create(ruta))
            {
                archivo.CopyTo(stream);
            }

            var pedidos = _excelService.LeerPedidos(ruta).ToList();

            foreach (var pedido in pedidos)
            {
                if (!await _validacionService.ValidarStockAsync(
                        pedido.Detalle,
                        _stockService,
                        pedido.Cabecera.TipoCodigo,
                        out var error))
                {
                    return BadRequest(error);
                }
            }

            return Ok(pedidos);
        }
    }
}
