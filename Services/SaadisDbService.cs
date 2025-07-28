using System.Data.SqlClient;
using ValidadorPedidos.Models;

namespace ValidadorPedidos.Services
{
    public class SaadisDbService
    {
        private readonly string _connectionString;

        public SaadisDbService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertarPedido(PedidoSaadisDto pedido)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand("INSERT INTO RECHRDE(Numero,ClienteCodigo,FechaCreacion) VALUES(@num,@cli,@fec)", connection);
            command.Parameters.AddWithValue("@num", pedido.Numero);
            command.Parameters.AddWithValue("@cli", pedido.ClienteCodigo);
            command.Parameters.AddWithValue("@fec", pedido.FechaCreacion);
            command.ExecuteNonQuery();
        }
    }
}
