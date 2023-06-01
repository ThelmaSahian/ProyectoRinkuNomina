using RinkuNomina.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RinkuNomina.Domain.Model
{
    public class EntregasPorEmpleado : IBitacora
    {
        [Key]
        [Required]
        public Guid IdEntrega { get; set; }

        [Required]
        public Guid IdEmpleado { get; set; }

        [Required]
        public DateTime FechaEntrega { get; set; }

        public Guid? IdClienteEntrega { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }

        public decimal CantidadEntregas { get; set; }
    }
}
