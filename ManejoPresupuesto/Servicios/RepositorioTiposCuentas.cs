using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios.Interfaces;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;
        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(
                $@"INSERT INTO TiposCuentas(Nombre, UsuarioId, Orden)
                   Values(@Nombre, @UsuarioId, 0);
                   SELECT SCOPE_IDENTITY();", tipoCuenta);
            tipoCuenta.Id = id;
        }
    }
}
