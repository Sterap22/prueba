using Login.Dtos;
using Login.Models;
using Login.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices UsaurioServices;

        public UsuarioController(IUsuarioServices usaurioServices)
        {
            UsaurioServices = usaurioServices;
        }
        [HttpPost("loginSesion")]
        public async Task<IActionResult> PostLog([FromBody] LoginDTO value)
        {
            var respuesta = UsaurioServices.LoginSession(value);
            return Ok(respuesta.Result);
        }
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> PostReg([FromBody] UsuarioInfo value)
        {
            var respuesta = UsaurioServices.Save(value);
            return Ok(respuesta.Result);
        }
    }
}
