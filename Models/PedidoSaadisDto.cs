using System;
using System.Collections.Generic;

namespace ValidadorPedidos.Models
{
    /// <summary>
    /// Datos necesarios para insertar en la tabla RECHRDE.
    /// Solo se incluyen algunos campos representativos.
    /// </summary>
    public class PedidoSaadisDto
    {
        public string? RHD_NROCLI { get; set; }
        public string? CBT_CODCBT { get; set; }
        public string? CBT_CENEMI { get; set; }
        public string? CBT_NROCBT { get; set; }
        public string? CBT_LETCBT { get; set; }
        public DateTime CBT_FECCBT { get; set; }
        public string? CBT_DETALL { get; set; }

        public List<DetalleDto> Detalle { get; set; } = new();
    }
}
