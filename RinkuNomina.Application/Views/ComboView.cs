namespace RinkuNomina.Application.Views
{
    public class ComboView
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public ComboView(dynamic model)
        {
            Id = model.IdRol ?? model.IdEmpleado;
            Text = model.Descripcion ?? $"{model.Nombre} {model.ApellidoPaterno} {model.ApellidoMaterno}";
        }
    }
}
