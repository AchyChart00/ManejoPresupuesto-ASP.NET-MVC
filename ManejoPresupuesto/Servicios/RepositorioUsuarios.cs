﻿using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios.Interfaces;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string connectionString;
        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> CrearUsuario(Usuario usuario)
        {
            //usuario.EmailNormalizado = usuario.Email.ToUpper();
            using var connection = new SqlConnection(connectionString);
            var usuarioId = await connection.QuerySingleAsync<int>(@"INSERT INTO Usuarios  (Email, EmailNormalizado, PasswordHash)
                                                            VALUES(@Email, @EmailNormalizado, @PasswordHash);
                                                            SELECT SCOPE_IDENTITY();", usuario);

            await connection.ExecuteAsync("CrearDatosUsuarioNuevo", new {
                usuarioId
            }, commandType: System.Data.CommandType.StoredProcedure);

            return usuarioId;  
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string emailNormalizado)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE EmailNormalizado = @emailNormalizado", new { emailNormalizado});
        }
    }
}
