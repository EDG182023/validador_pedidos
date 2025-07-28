namespace ValidadorPedidos.Models
{
    public class DetalleDto
    {
        public int Linea { get; set; }
        public string ProductoCodigo { get; set; } = string.Empty;
        public string ProductoCompaniaCodigo { get; set; } = string.Empty;
        public string LoteCodigo { get; set; } = string.Empty;
        public DateTime? LoteVencimiento { get; set; }
        public string? Serie { get; set; }
        public int Cantidad { get; set; }
        public bool DespachoParcial { get; set; }
    }
}
