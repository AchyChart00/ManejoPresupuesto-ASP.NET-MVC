using ManejoPresupuesto.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta //: IValidatableObject
    {
        public int Id { get; set; }
        //Validaciones
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [PrimeraLetraMayuscula]
        [Remote(action: "VerificarExisteTipoCuenta", controller:"TiposCuentas")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Nombre != null && Nombre.Length > 0)
            {
                var primeraLetra = Nombre[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult(
                        "La primera letra debe de ser mayúscula", 
                        new[] { nameof(Nombre)}// si no especifico el nombre de la variable a validar, entonces lo considera ASP .NET como error a nivel de modelo, ya que no tiene que ver con un campo en especifico. 
                        );
                }
            }
        }*/
    }
}
