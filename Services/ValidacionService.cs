using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    public class ValidacionService
    {
        public bool ValidarCabecera(CabeceraDto cabecera, out string error)
        {
            if (string.IsNullOrWhiteSpace(cabecera.ClienteCodigo))
            {
                error = "ClienteCodigo es requerido";
                return false;
            }

            if (cabecera.Numero <= 0)
            {
                error = "Numero inválido";
                return false;
            }

            error = string.Empty;
            return true;
        }
    }
}
