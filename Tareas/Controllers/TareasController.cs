using Microsoft.AspNetCore.Mvc;
using Tareas.DTOS;
using Tareas.Models;
using Tareas.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ITareasServices TareasServ;

        public TareasController(ITareasServices tareasServ)
        {
            TareasServ = tareasServ;
        }
        [HttpGet("traerTareas/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var respuesta = TareasServ.Get(id);
            return Ok(respuesta);
        }
        [HttpPost("CrearTarea")]
        public async Task<IActionResult> PostTarea([FromBody] TareasProgramadas value)
        {
            var respuesta = TareasServ.Save(value);
            return Ok(respuesta.Result);
        }
        [HttpPut("Actualizartarea/{id}")]
        public async Task<IActionResult> Put([FromBody] TareasProgramadas value)
        {
            var respuesta = TareasServ.Update(value);
            return Ok(respuesta.Result);
        }
    }
}
