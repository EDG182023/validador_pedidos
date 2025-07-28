from fastapi import FastAPI
from .routers import remito

app = FastAPI()

app.include_router(remito.router, prefix="/api")
