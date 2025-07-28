import requests
from ..models.dtos import PedidoSaadDto

class SaadApiService:
    def enviar_pedido(self, pedido: PedidoSaadDto, url: str) -> None:
        requests.post(url, json=pedido.dict())
