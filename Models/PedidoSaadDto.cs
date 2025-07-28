using System;
using System.Collections.Generic;

namespace ValidadorPedidos.Models
{
    /// <summary>
    /// Representa el JSON enviado a la API SAAD.
    /// Se incluyen solo algunos campos relevantes.
    /// </summary>
    public class PedidoSaadDto
    {
        public string? AlmacenCodigo { get; set; }
        public string? AlmacenEmplazamientoCodigo { get; set; }
        public string? TipoCodigo { get; set; }
        public string? Categoria { get; set; }
        public string? Sucursal { get; set; }
        public int Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string? ClienteCodigo { get; set; }
        public string? SubClienteCodigo { get; set; }
        public string? SubClienteDescripcion { get; set; }
        public string? Domicilio { get; set; }
        public string? LocalidadCodigo { get; set; }
        public decimal ImporteFactura { get; set; }
        public int ContraReembolso { get; set; }
        public int Prioridad { get; set; }
        public string? Observaciones { get; set; }
        public List<DetalleDto> Detalle { get; set; } = new();
    }
}
