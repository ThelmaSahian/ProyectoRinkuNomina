using RinkuNomina.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RinkuNomina.Domain.Model
{
    public class FrecuenciaBono : IBitacora
    {
        [Key]
        [Required]
        public Guid IdFrecuenciaBono { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }
    }
}
