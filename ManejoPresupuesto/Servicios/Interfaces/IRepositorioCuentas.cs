using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios.Interfaces
{
    public interface IRepositorioCuentas
    {
        Task actualizar(CuentaCreacionViewModel cuenta);
        Task<IEnumerable<Cuenta>> Buscar(int usuarioId);
        Task Crear(Cuenta cuenta);
        Task<Cuenta> ObtenerPorId(int id, int usuarioId);
    }
}
