using RinkuNomina.Domain.Common;
using RinkuNominaDomain.Common;
using System.ComponentModel.DataAnnotations;

namespace RinkuNominaDomain.Model
{
    public class Empleado : IBitacora, IEmpleados
    {
        [Key]
        [Required]
        public Guid IdEmpleado { get; set; }

        [Required]
        public Guid IdRol { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string ApellidoPaterno { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string ApellidoMaterno { get; set; } = string.Empty;

        [Required]
        public bool Activo { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }

        [Required]
        public int NumeroEmpleado { get; set; }

    }
}
