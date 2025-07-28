namespace ValidadorPedidos.Models
{
    public class PedidoSaadisDto
    {
        public int Numero { get; set; }
        public string ClienteCodigo { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
