namespace ValidadorPedidos.Models
{
    /// <summary>
    /// Representa un item del pedido.
    /// </summary>
    public class DetalleDto
    {
        public int Linea { get; set; }
        public string? ProductoCodigo { get; set; }
        public decimal Cantidad { get; set; }
    }
}
