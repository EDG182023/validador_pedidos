using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    /// <summary>
    /// Servicio sencillo para leer pedidos desde un archivo Excel.
    /// </summary>
    public class ExcelService
    {
        public async Task<List<PedidoSaadisDto>> LeerPedidosAsync(Stream stream)
        {
            var pedidos = new List<PedidoSaadisDto>();
            using var package = new ExcelPackage();
            await package.LoadAsync(stream);
            // Aquí se mapearían las filas a objetos PedidoSaadisDto.
            return pedidos;
        }
    }
}
