using System.Data.SqlClient;
using System.Threading.Tasks;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    /// <summary>
    /// Maneja la inserción en la tabla RECHRDE de SAADIS.
    /// </summary>
    public class SaadisDbService
    {
        private readonly string _connectionString;

        public SaadisDbService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Inserta un registro en RECHRDE si el tipo de comprobante es "10"
        /// y el pedido no posee detalle.
        /// </summary>
        public async Task InsertRechrdeAsync(PedidoSaadisDto pedido)
        {
            if (pedido == null)
                throw new System.ArgumentNullException(nameof(pedido));

            if (pedido.CBT_CODCBT != "10" || (pedido.Detalle != null && pedido.Detalle.Count > 0))
                return; // No corresponde insert

            const string sql = @"INSERT INTO RECHRDE
                (RHD_NROCLI, CBT_CODCBT, CBT_CENEMI, CBT_NROCBT, CBT_LETCBT,
                 CBT_FECCBT, cbt_detall)
                VALUES
                (@NroCli, @CodCbt, @CenEmi, @NroCbt, @LetCbt,
                 @FecCbt, @Detall)";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NroCli", pedido.RHD_NROCLI ?? (object)System.DBNull.Value);
            command.Parameters.AddWithValue("@CodCbt", pedido.CBT_CODCBT ?? (object)System.DBNull.Value);
            command.Parameters.AddWithValue("@CenEmi", pedido.CBT_CENEMI ?? (object)System.DBNull.Value);
            command.Parameters.AddWithValue("@NroCbt", pedido.CBT_NROCBT ?? (object)System.DBNull.Value);
            command.Parameters.AddWithValue("@LetCbt", pedido.CBT_LETCBT ?? (object)System.DBNull.Value);
            command.Parameters.AddWithValue("@FecCbt", pedido.CBT_FECCBT);
            command.Parameters.AddWithValue("@Detall", pedido.CBT_DETALL ?? string.Empty);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}
