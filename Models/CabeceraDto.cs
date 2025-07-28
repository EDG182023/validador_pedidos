namespace ValidadorPedidos.Models
{
    public class CabeceraDto
    {
        public string AlmacenCodigo { get; set; } = string.Empty;
        public string AlmacenEmplazamientoCodigo { get; set; } = string.Empty;
        public string TipoCodigo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Sucursal { get; set; } = string.Empty;
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string ClienteCodigo { get; set; } = string.Empty;
        public bool EntregaParcial { get; set; }
        public decimal ImporteFactura { get; set; }
    }
}
