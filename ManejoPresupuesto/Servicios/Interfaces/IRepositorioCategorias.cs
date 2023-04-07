using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios.Interfaces
{
    public interface IRepositorioCategorias
    {
        Task Crear(Categoria categoria);
    }
}
