using OfficeOpenXml;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    public class ExcelService
    {
        public IEnumerable<PedidoSaadDto> LeerPedidos(string rutaArchivo)
        {
            var pedidos = new List<PedidoSaadDto>();
            using var package = new ExcelPackage(new FileInfo(rutaArchivo));
            var ws = package.Workbook.Worksheets[0];

            for (int row = 2; ws.Cells[row, 1].Value != null; row++)
            {
                var cabecera = new CabeceraDto
                {
                    Numero = Convert.ToInt32(ws.Cells[row, 1].Value),
                    ClienteCodigo = ws.Cells[row, 2].Text,
                    FechaEmision = DateTime.Parse(ws.Cells[row, 3].Text),
                    TipoCodigo = ws.Cells[row, 6].Text
                };

                var detalle = new List<DetalleDto>
                {
                    new DetalleDto
                    {
                        Linea = 1,
                        ProductoCodigo = ws.Cells[row, 4].Text,
                        Cantidad = Convert.ToInt32(ws.Cells[row, 5].Value),
                        ProductoCompaniaCodigo = ws.Cells[row, 6].Text
                    }
                };

                pedidos.Add(new PedidoSaadDto
                {
                    Cabecera = cabecera,
                    Detalle = detalle
                });
            }

            return pedidos;
        }
    }
}
