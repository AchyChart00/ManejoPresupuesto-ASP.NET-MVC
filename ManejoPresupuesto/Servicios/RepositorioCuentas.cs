using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios.Interfaces;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioCuentas : IRepositorioCuentas
    {
        private readonly string connectionString;
        public RepositorioCuentas(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Cuenta cuenta)
        {
            using var connection = new SqlConnection(connectionString);
            //Obtenemos el id que se acaba de insertar con SCOPE_IDENTITY
            //Para poder llevar al usuario a la página destino. 
            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO Cuentas (Nombre, TipoCuentaId, Descripcion, Balance)
                                                        VALUES(@Nombre, @TipoCuentaId, @Descripcion, @Balance);

                                                        SELECT SCOPE_IDENTITY();", cuenta);

            cuenta.Id = id;
        }

    }
}
