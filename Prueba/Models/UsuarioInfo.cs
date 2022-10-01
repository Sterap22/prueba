namespace Login.Models
{
    public class UsuarioInfo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public DateTime fechaCreacion { get; set; }
        public bool vigente { get; set; }
    }
}
