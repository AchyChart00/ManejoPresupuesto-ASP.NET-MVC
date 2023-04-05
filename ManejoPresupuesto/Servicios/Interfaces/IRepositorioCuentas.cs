using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios.Interfaces
{
    public interface IRepositorioCuentas
    {
        Task Crear(Cuenta cuenta);
    }
}
