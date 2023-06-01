using RinkuNominaDomain.Common;

namespace RinkuNomina.Application.Views
{
    public class EmpleadoView
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int NumeroEmpleado { get; set; }
        public Guid IdRol { get; set; }

        public EmpleadoView(IEmpleados model)
        {
            Id = model.IdEmpleado;
            Text = $"{model.Nombre} {model.ApellidoPaterno} {model.ApellidoMaterno}";
            NumeroEmpleado = model.NumeroEmpleado;
            IdRol = model.IdRol;
        }
    }
}
