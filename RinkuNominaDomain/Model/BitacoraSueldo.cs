﻿using RinkuNomina.Domain.Common;
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
        public DateTime FechaCreacion { get; set; }

        [Required]
        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }

        [Required]
        public int HorasTrabajadas { get; set; }

        [Required]
        public decimal PagoTotalBonos { get; set; }

        [Required]
        public decimal Retencion { get; set; }

        [Required]
        public decimal Vales { get; set; }

        [Required]
        public decimal SueldoTotal { get; set; }

        public Guid? IdEntregaEmpleado { get; set; }
    }
}
