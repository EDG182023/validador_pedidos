using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    /// <summary>
    /// Cliente HTTP para comunicarse con la API de SAAD.
    /// </summary>
    public class SaadApiService
    {
        private readonly HttpClient _httpClient;

        public SaadApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarPedidoAsync(PedidoSaadDto pedido, string url)
        {
            var json = JsonSerializer.Serialize(pedido);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(url, content);
        }
    }
}
