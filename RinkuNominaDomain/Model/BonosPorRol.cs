using RinkuNomina.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RinkuNomina.Domain.Model
{
    public class BonosPorRol : IBitacora
    {
        [Key]
        [Required]
        public Guid IdBonoRol { get; set; }

        [Required]
        public Guid IdRol { get; set; }

        [Required]
        public Guid IdTipoBono { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public Guid IdFrecuenciaBono { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }
    }
}
