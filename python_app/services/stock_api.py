import requests

class StockApiService:
    def obtener_stock(self, url: str) -> str:
        resp = requests.get(url)
        return resp.text
