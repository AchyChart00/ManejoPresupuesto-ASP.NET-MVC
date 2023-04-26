﻿using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe de ser un correo electrónico válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]//con dataType es como el atributo TYPE de la etiqueta INPUT en HTML
        public string Password { get; set; }
        public bool Recuerdame { get; set; }
    }
}
