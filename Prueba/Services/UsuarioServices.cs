using Login.Dtos;
using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login.Services
{
    public class UsuarioServices: IUsuarioServices
    {
        ConectionModels _context;

        public UsuarioServices(ConectionModels context)
        {
            _context = context;
        }
        //Login
        public async Task<RespuestaDTO> LoginSession(LoginDTO uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            { 
                var usuarioAc = await _context.usuario.FirstOrDefaultAsync(x => x.correo == uss.correo && x.clave == uss.clave && x.vigente == true);
                if (usuarioAc != null)
                {
                    //respuestaVi.token = GeneratiToken(uss, configuration);
                    respuestaVi.mensaje = "Se inicio sesion exitosamente";
                    return respuestaVi;
                }
                else
                {
                    respuestaVi.mensaje = "No se encontro el usuario";
                    return respuestaVi;
                }
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }
        }
        //registro
        public async Task<RespuestaDTO> Save(UsuarioInfo uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            {
                var usuarioAc = await _context.usuario.FirstOrDefaultAsync(x => x.correo == uss.correo);
                if (usuarioAc != null)
                {
                    _context.usuario.Add(uss);
                    respuestaVi.mensaje = "Se creo el usuario correctamente";
                }
                else
                {
                    respuestaVi.mensaje = "Correo en uso";
                }
                return respuestaVi;
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }
        }
    }
    public interface IUsuarioServices
    {
        Task<RespuestaDTO> LoginSession(LoginDTO uss);
        Task<RespuestaDTO> Save(UsuarioInfo uss);
    }
}
