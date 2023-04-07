using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios.Interfaces
{
    public interface IRepositorioTransacciones
    {
        Task Crear(Transaccion transaccion);
    }
}
