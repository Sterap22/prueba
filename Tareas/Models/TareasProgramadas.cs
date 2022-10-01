namespace Tareas.Models
{
    public class TareasProgramadas
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string asunto { get; set; }
        public string actividad { get; set; }
        public string hora { get; set; }
        public DateTime fechaActividad { get; set; }
        public DateTime fechaCreacion { get; set; }
        public bool vigente { get; set; }
    }
}
