using System;

namespace ValidadorPedidos.Models
{
    /// <summary>
    /// Datos generales del pedido.
    /// </summary>
    public class CabeceraDto
    {
        public string? ClienteCodigo { get; set; }
        public string? Numero { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
