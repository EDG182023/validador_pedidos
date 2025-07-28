from ..models.dtos import PedidoSaadisDto

class ValidacionService:
    def posee_detalle(self, pedido: PedidoSaadisDto) -> bool:
        return bool(pedido.detalle)
