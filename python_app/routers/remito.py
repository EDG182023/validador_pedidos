from fastapi import APIRouter, Depends
from ..models.dtos import PedidoSaadisDto
from ..services.saadis_db import SaadisDbService

router = APIRouter()

def get_db() -> SaadisDbService:
    # Placeholder connection string
    return SaadisDbService("DRIVER={ODBC Driver 17 for SQL Server};SERVER=localhost;DATABASE=saadis;UID=user;PWD=pass")

@router.post("/remito")
def crear_remito(pedido: PedidoSaadisDto, db: SaadisDbService = Depends(get_db)):
    db.insert_rechrde(pedido)
    return {"status": "ok"}
