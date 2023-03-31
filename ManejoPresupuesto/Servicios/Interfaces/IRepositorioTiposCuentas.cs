using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicios.Interfaces
{
    public interface IRepositorioTiposCuentas
    {
        Task Crear(TipoCuenta tipoCuenta);
    }
}
