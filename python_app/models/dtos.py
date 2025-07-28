from datetime import datetime
from typing import List, Optional
from pydantic import BaseModel

class CabeceraDto(BaseModel):
    cliente_codigo: Optional[str]
    numero: Optional[str]
    fecha_emision: datetime

class DetalleDto(BaseModel):
    linea: int
    producto_codigo: Optional[str]
    cantidad: float

class PedidoSaadDto(BaseModel):
    almacen_codigo: Optional[str]
    almacen_emplazamiento_codigo: Optional[str]
    tipo_codigo: Optional[str]
    categoria: Optional[str]
    sucursal: Optional[str]
    numero: int
    fecha_emision: datetime
    fecha_entrega: datetime
    cliente_codigo: Optional[str]
    sub_cliente_codigo: Optional[str]
    sub_cliente_descripcion: Optional[str]
    domicilio: Optional[str]
    localidad_codigo: Optional[str]
    importe_factura: float
    contra_reembolso: int
    prioridad: int
    observaciones: Optional[str]
    detalle: List[DetalleDto] = []

class PedidoSaadisDto(BaseModel):
    rhd_nrocli: Optional[str]
    cbt_codcbt: Optional[str]
    cbt_cenemi: Optional[str]
    cbt_nrocbt: Optional[str]
    cbt_letcbt: Optional[str]
    cbt_feccbt: datetime
    cbt_detall: Optional[str]
    detalle: List[DetalleDto] = []
