import pyodbc
from ..models.dtos import PedidoSaadisDto

class SaadisDbService:
    def __init__(self, connection_string: str) -> None:
        self.connection_string = connection_string

    def insert_rechrde(self, pedido: PedidoSaadisDto) -> None:
        if pedido.cbt_codcbt != "10" or pedido.detalle:
            return
        sql = (
            "INSERT INTO RECHRDE (RHD_NROCLI, CBT_CODCBT, CBT_CENEMI, CBT_NROCBT, "
            "CBT_LETCBT, CBT_FECCBT, cbt_detall) "
            "VALUES (?, ?, ?, ?, ?, ?, ?)"
        )
        with pyodbc.connect(self.connection_string) as conn:
            with conn.cursor() as cur:
                cur.execute(
                    sql,
                    pedido.rhd_nrocli,
                    pedido.cbt_codcbt,
                    pedido.cbt_cenemi,
                    pedido.cbt_nrocbt,
                    pedido.cbt_letcbt,
                    pedido.cbt_feccbt,
                    pedido.cbt_detall or "",
                )
                conn.commit()
