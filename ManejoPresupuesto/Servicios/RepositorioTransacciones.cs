﻿using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios.Interfaces;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioTransacciones : IRepositorioTransacciones
    {
        private readonly string connectionString;
        public RepositorioTransacciones(
                IConfiguration configuration
            )
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Transaccion transaccion)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(
                    "Transacciones_Insertar",
                    new { transaccion.UsuarioId, transaccion.FechaTransaccion, transaccion.Monto, transaccion.CategoriaId, transaccion.CuentaId, transaccion.Nota},
                    commandType: System.Data.CommandType.StoredProcedure
                );
            transaccion.Id = id;    
        }

        public async Task Actualizar(
            Transaccion transaccion, 
            decimal montoAnterior,
            int cuentaAnterior
            )
        {
            using var connection = new SqlConnection (connectionString);
            await connection.ExecuteAsync(
                "Transacciones_Actualizar", 
                new 
                { 
                    transaccion.Id, 
                    transaccion.FechaTransaccion,
                    transaccion.Monto,
                    transaccion.CategoriaId,
                    transaccion.CuentaId,
                    transaccion.Nota,
                    montoAnterior,
                    cuentaAnterior

                },
                commandType: System.Data.CommandType.StoredProcedure
                );

        }

        public async Task<Transaccion> ObtenerPorId(int id, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Transaccion>(@"SELECT 
	                                                                            Transacciones.*,
	                                                                            cat.TipoOperacionId
                                                                            FROM Transacciones
                                                                            INNER JOIN Categorias cat
                                                                            ON cat.Id = Transacciones.CategoriaId
                                                                            WHERE Transacciones.Id = @Id AND Transacciones.UsuarioId = @UsuarioId",
                                                                            new { id, usuarioId});

        }

    }
}
