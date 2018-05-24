using System;
using System.ComponentModel.DataAnnotations;

namespace Trepapp.Models
{
    public class Escalador
    {
        public int EscaladorId { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 carácteres")]
        public string NombreApellido { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "La contraseña debe tener entre 4 y 20 carácteres")]
        public string Password { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "El nick debe tener entre 4 y 20 carácteres")]
        public string Nick { get; set; }
        [Required]
        public DateTime DataNeixament { get; set; }
        public Boolean Federat { get; set; }
    }
}
