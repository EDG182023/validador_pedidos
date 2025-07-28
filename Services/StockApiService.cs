using System.Net.Http;
using System.Threading.Tasks;

namespace ValidadorPedidos.Services
{
    public class StockApiService
    {
        private readonly HttpClient _client;

        public StockApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> ObtenerStockAsync(DateTime fecha, string compania)
        {
            string url = $"esa-api-integraciones/api/stock/get/{fecha:yyyy-MM-dd}/{compania}";
            return await _client.GetStringAsync(url);
        }
    }
}
