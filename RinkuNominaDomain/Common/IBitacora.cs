namespace RinkuNomina.Domain.Common
{
    public interface IBitacora
    {
        public DateTime FechaCreacion { get; set; }

        public Guid IdUsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Guid? IdUsuarioModificacion { get; set; }
    }
}
