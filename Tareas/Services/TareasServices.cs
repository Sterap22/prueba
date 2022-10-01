using Microsoft.EntityFrameworkCore;
using Tareas.DTOS;
using Tareas.Models;

namespace Tareas.Services
{
    public class TareasServices: ITareasServices
    {
        ConectionModels _context;
        public async Task<TareasProgramadas> Get(int uss)
        {
            var respuestaVi = new TareasProgramadas();
            try
            {
                var res =  await _context.tarea.FirstOrDefaultAsync(x => x.Id == uss && x.vigente == true);
                if (res == null)
                {
                    respuestaVi = res;
                }
                return respuestaVi;
            }
            catch (Exception)
            {

                return respuestaVi;
            }
        }
        public async Task<RespuestaDTO> Save(TareasProgramadas uss)
        {
            var respuestaVi = new RespuestaDTO();
            try 
            { 
                _context.tarea.Add(uss);
                respuestaVi.mensaje = "Se creo la tarea correctamente";
                return respuestaVi;
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }
        }
        public async Task<RespuestaDTO> Update(TareasProgramadas uss)
        {
            var respuestaVi = new RespuestaDTO();
            try
            {
                var usuarioAc = _context.tarea.Find(uss.Id);

                if (usuarioAc != null)
                {
                    usuarioAc = uss;

                    await _context.SaveChangesAsync();
                    respuestaVi.mensaje = "Se actualizo la tarea con correctamente";
                    return respuestaVi;
                }
                else
                {
                    respuestaVi.mensaje = "No se encontro la tarea seleccionada";
                    return respuestaVi;
                }
            }
            catch (Exception ex)
            {
                respuestaVi.mensaje = ex.Message;
                return respuestaVi;
            }

        }
    }
    public interface ITareasServices
    {
        Task<RespuestaDTO> Save(TareasProgramadas uss);
        Task<RespuestaDTO> Update(TareasProgramadas uss);
        Task<TareasProgramadas> Get(int uss);
    }
}
