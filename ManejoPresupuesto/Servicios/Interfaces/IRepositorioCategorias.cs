﻿using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios.Interfaces
{
    public interface IRepositorioCategorias
    {
        Task Actualizar(Categoria categoria);
        Task Borrar(int id);
        Task Crear(Categoria categoria);
        Task<IEnumerable<Categoria>> Obtener(int usuarioId, TipoOperacion tipoOperacionId);
        Task<IEnumerable<Categoria>> Obtener(int usuarioId, PaginacionViewModel paginacion);
        Task<Categoria> ObtenerPorId(int id, int usuarioId);
    }
}
