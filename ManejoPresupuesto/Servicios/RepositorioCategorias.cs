﻿using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios.Interfaces;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly string connectionString;
        public RepositorioCategorias(
                IConfiguration configuration
            )
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");  
        }

        public async Task Crear(Categoria categoria)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO Categorias(Nombre, TipoOperacionId, UsuarioId)
                                                            VALUES(@Nombre, @TipoOperacionId, @UsuarioId);

                                                            SELECT SCOPE_IDENTITY();", categoria);
            
            categoria.Id = id;
            
        }

        public async Task<IEnumerable<Categoria>> Obtener(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<Categoria>(
                "SELECT * FROM Categorias WHERE UsuarioId = @UsuarioId",
                new { usuarioId}
                );
        }
    }
}
