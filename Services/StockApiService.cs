using System.Net.Http;
using System.Threading.Tasks;

namespace ValidadorPedidos.Services
{
    /// <summary>
    /// Servicio mínimo para consultar stock.
    /// </summary>
    public class StockApiService
    {
        private readonly HttpClient _httpClient;

        public StockApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ObtenerStockAsync(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }
    }
}
