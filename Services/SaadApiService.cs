using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    public class SaadApiService
    {
        private readonly HttpClient _client;

        public SaadApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> EnviarPedidoAsync(PedidoSaadDto pedido, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(new[] { pedido });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync("esa-api-integraciones/api/saadpedidos/crear", content);
        }
    }
}
