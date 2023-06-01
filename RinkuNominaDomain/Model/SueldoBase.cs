using RinkuNomina.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RinkuNomina.Domain.Model
{
    public class SueldoBase : IBitacora
    {
        [Key]
        [Required]
        public Guid IdSueldoBase { get; set; }

        [Required]
        public Guid IdEmpleado { get; set; }

        [Required]
        public decimal CantidadPorHora { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }
    }
}
