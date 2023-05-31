using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RinkuNomina.Domain.Model
{
    public class Usuario
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdUsuario { get; set; }

        [Required]
        [MaxLength(200)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [MaxLength(254)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(128)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public Guid? IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }
    }
}
