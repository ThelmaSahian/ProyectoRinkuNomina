namespace RinkuNomina.Application.Views
{
    public class EmpleadoView
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string NumeroTelefono { get; set; }
        public Guid IdRol { get; set; }

        public EmpleadoView(dynamic model)
        {
            Id = model.IdEmpleado;
            Text = $"{model.Nombre} {model.ApellidoPaterno} {model.ApellidoMaterno}";
            NumeroTelefono = model.NumeroTelefono;
            IdRol = model.IdRol;
        }
    }
}
