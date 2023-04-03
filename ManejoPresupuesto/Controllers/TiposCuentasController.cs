using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuentas repositorioTiposCuentas;

        public TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas)
        {
            this.repositorioTiposCuentas = repositorioTiposCuentas;
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            //Con este código evito que los valores introducidos en el formulario se pierdan
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }
            tipoCuenta.UsuarioId = 1;

            var yaExisteTipoCuenta = 
                await repositorioTiposCuentas.Existe(
                    tipoCuenta.Nombre, 
                    tipoCuenta.UsuarioId
                    );
            if (yaExisteTipoCuenta)
            {
                ModelState.AddModelError(
                    nameof(tipoCuenta.Nombre), 
                    $"El nombre {tipoCuenta.Nombre} ya existe."
                    );

                return View(tipoCuenta);
            }

            await repositorioTiposCuentas.Crear(tipoCuenta);

            return View();
        }
    }
}
