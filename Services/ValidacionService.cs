using ValidadorPedidos.Models;
using System.Threading.Tasks;

namespace ValidadorPedidos.Services
{
    public class ValidacionService
    {
        public bool ValidarCabecera(CabeceraDto cabecera, out string error)
        {
            if (string.IsNullOrWhiteSpace(cabecera.ClienteCodigo))
            {
                error = "ClienteCodigo es requerido";
                return false;
            }

            if (cabecera.Numero <= 0)
            {
                error = "Numero inválido";
                return false;
            }

            error = string.Empty;
            return true;
        }

        public async Task<bool> ValidarStockAsync(
            IEnumerable<DetalleDto> detalle,
            StockApiService stockService,
            string compania,
            out string error)
        {
            foreach (var item in detalle)
            {
                var resp = await stockService.ObtenerStockAsync(DateTime.Today, compania);

                if (!int.TryParse(resp, out var disponible) || disponible < item.Cantidad)
                {
                    error = $"Stock insuficiente para producto {item.ProductoCodigo}";
                    return false;
                }
            }

            error = string.Empty;
            return true;
        }
    }
}
