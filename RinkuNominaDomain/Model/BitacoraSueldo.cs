using RinkuNomina.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RinkuNomina.Domain.Model
{
    public class BitacoraSueldo : IBitacora
    {
        [Key]
        [Required]
        public Guid IdBitacoraSueldo { get; set; }

        [Required]
        public Guid IdEmpleado { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }
    }
}
