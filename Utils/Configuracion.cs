namespace ValidadorPedidos.Utils
{
    /// <summary>
    /// Configuración básica para la aplicación.
    /// </summary>
    public static class Configuracion
    {
        /// <summary>
        /// Cadena de conexión a SAADIS.
        /// Puede establecerse desde appsettings.json o variables de entorno.
        /// </summary>
        public static string SaadisConnectionString { get; set; } = string.Empty;
    }
}
