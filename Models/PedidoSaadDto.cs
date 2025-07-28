namespace ValidadorPedidos.Models
{
    public class PedidoSaadDto
    {
        public CabeceraDto Cabecera { get; set; } = new();
        public List<DetalleDto> Detalle { get; set; } = new();
    }
}
