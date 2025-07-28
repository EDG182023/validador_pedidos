# validador_pedidos
Validación de pedidos al subir 

API OBSTENER TOKEN:             curl --location 'https://soft.esalogistica.com.ar/esa-api-integraciones/api/auth/autenticar' \
            --header 'Content-Type: application/json' \
            --data '{
                "usuario":"esa-logistica",
                "hash": "esa-logistica2024!"
            }'

API CARGA PEDIDOS:   curl --location 'https://soft.esalogistica.com.ar/esa-api-integraciones/api/saadpedidos/crear' \
            --header 'Content-Type: application/json' \
            --header 'Authorization: TOKEN_OBTENIDO' \
            --data '[{
                "almacenCodigo": "002",
                "almacenEmplazamientoCodigo": "002",
                "tipoCodigo": "DON",
                "categoria": "R",
                "sucursal": "0001",
                "numero": 378999,
                "fechaEmision": "2024-07-03T21:04:28.231Z",
                "fechaEntrega": "2024-07-03T21:04:28.231Z",
                "clienteCodigo": "0000000042",
                "subClienteCodigo": "0000000332",
                "subClienteDescripcion": "Subcliente test",
                "subClienteAreaMuelleCodigo": "000001",
                "subClienteDomicilio": "BALCARCE 646 PB",
                "subClienteLocalidadCodigo": "001",
                "subClienteProvincia": "BUE",
                "subClientePais": "ARG",
                "subClienteIva": "01",
                "subClienteCuit": "33679726329",
                "subClienteTelefono": "1199999999",
                "razonSocial": "Subcliente test dev",
                "depositoCodigo": "Monteagudo",
                "localidadCodigo": "1007",
                "provincia": null,
                "domicilio": "Castañon 3561",
                "centroCostoCodigo": null,
                "areaMuelleCodigo": null,
                "numeroRuteo": null,
                "entregaParcial": true,
                "importeFactura": 1.00,
                "contraReembolso": 1,
                "prioridad": 1,
                "referenciaA": "referenciaA",
                "referenciaB": "referenciaB",
                "observaciones": "observaciones",
                "detalle": [{
                    "linea": 0,
                    "productoCodigo": "caja",
                    "productoCompaniaCodigo": "DON",
                    "loteCodigo": "L1",
                    "loteVencimiento": "2024-07-03T21:04:28.231Z",
                    "serie": "123",
                    "cantidad": 1,
                    "despachoParcial": false
                }, {
                    "linea": 1,
                    "productoCodigo": "caja",
                    "productoCompaniaCodigo": "DON",
                    "loteCodigo": "L1",
                    "loteVencimiento": "2024-07-03T21:04:28.231Z",
                    "serie": "223",
                    "cantidad": 10,
                    "despachoParcial": false
                }, {
                    "linea": 2,
                    "productoCodigo": "caja",
                    "productoCompaniaCodigo": "DON",
                    "loteCodigo": "L1",
                    "loteVencimiento": "2024-07-03T21:04:28.231Z",
                    "serie": "333",
                    "cantidad": 5,
                    "despachoParcial": false
                }]
            }]'
			-------------------------MODELO CON COMENTARIOS----------------------------------
			[
    {
        "almacenCodigo": "002",//Valor fijo dependiendo el cleinte 
        "almacenEmplazamientoCodigo": "001",//Valor fijo depedniendo el cliente 
        "tipoCodigo": "DON",//Solicitar codigo de compañia a SISTEMAS 
        "categoria": "R", //Se pide la letra del comprobante
        "sucursal": "0002", //El centro emisor del comprobante
        "numero": 358989, //El numero de comprobante 
        "fechaEmision": "2024-07-03T21:04:28.231Z", //Fecha de emision del comprobante
        "fechaEntrega": "2024-07-03T21:04:28.231Z", //Fecha de emision del comprobante mas un dia, si es complejo repite la fecha de emision 
        "clienteCodigo": "0000000042", //Codigo de cliente solicitar a SISTEMAS
        "subClienteCodigo": "0000000001", //Codigo del destinatario si se maneja con maestros 
        "subClienteDescripcion": "Subcliente test", //Nombre del destinatario 
        //"subClienteDomicilio": "BALCARCE 646 PB", //Domicilio del destinatario
        //"subClienteTelefono": "1199999999", //Dato de contacto del destinatario 
        "razonSocial": "Subcliente test dev", //Nombre del destinatario 
        "depositoCodigo": "GradoZero", // Soliciar a SISTEMAS
        "localidadCodigo": "1007", //Codigo postal del destinatario 
        "provincia": null,
        "domicilio": "Castañon 3561", //Domicilio del destinatario 
        "entregaParcial": false,
        "importeFactura": 1.00, //Valor declarado 
        "prioridad": 1, // Simepre 1
        "referenciaA": "referenciaA", //Informacion importante para la entrega 
        "referenciaB": "referenciaB", //Informacion sobre el pedido 
        "observaciones": "observaciones", //Notaciones para el ejecutivo o concideraciones 
        "detalle": [
            {
                "linea": 0,
                "productoCodigo": "caja", //Codigo de producto
                "productoCompaniaCodigo": "DON", //Codigo de compañina 
                "loteCodigo": "L1", //Lote de producto
                "loteVencimiento": "2024-07-03T21:04:28.231Z", //Fecha de vencimiento del lote
                "cantidad": 1,
                "despachoParcial": false //Fijo en falso
            },
            {
                "linea": 1,
                "productoCodigo": "caja",
                "productoCompaniaCodigo": "DON",
                "loteCodigo": "L1",
                "loteVencimiento": "2024-07-03T21:04:28.231Z",
                "serie": "223",
                "cantidad": 10,
                "despachoParcial": false
            },
            {
                "linea": 2,
                "productoCodigo": "caja",
                "productoCompaniaCodigo": "DON",
                "loteCodigo": "L1",
                "loteVencimiento": "2024-07-03T21:04:28.231Z",
                "serie": "333",
                "cantidad": 5,
                "despachoParcial": false
            }
        ]
    }
]

API OBTENER STOCK:             curl --location 'https://soft.esalogistica.com.ar/esa-api-integraciones/api/stock/get/2024-10-03/CODIGO_COMPAÑIA' \
            --header 'Authorization: Bearer TOKEN_OBTENIDO' \
            --header 'Content-Type: application/json'

        
