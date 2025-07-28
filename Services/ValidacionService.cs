using System.Linq;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    /// <summary>
    /// Reglas de validación básicas.
    /// </summary>
    public class ValidacionService
    {
        public bool PoseeDetalle(PedidoSaadisDto pedido)
        {
            return pedido.Detalle != null && pedido.Detalle.Any();
        }
    }
}
