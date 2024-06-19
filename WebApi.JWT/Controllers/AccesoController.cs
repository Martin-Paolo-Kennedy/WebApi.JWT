using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.JWT.Custom;
using WebApi.JWT.Models;
using WebApi.JWT.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.JWT.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly BdJwtContext _dbjwtContext;
        private readonly Utilidades _utilidades;
        public AccesoController(BdJwtContext dbjwtContext, Utilidades utilidades)
        {
            _dbjwtContext = dbjwtContext;
            _utilidades = utilidades;
        }
        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(UsuarioDTO objeto)
        {
            var modeloUsuario = new TbUsuario
            {
                Nombre = objeto.Nombre,
                Correo = objeto.Correo,
                Clave = _utilidades.encriptarSHA256(objeto.Clave),
            };

            await _dbjwtContext.TbUsuarios.AddAsync(modeloUsuario);
            await _dbjwtContext.SaveChangesAsync();

            if (modeloUsuario.IdUsuario != 0)
            {
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true});
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbjwtContext.TbUsuarios
                                                .Where(u => u.Correo == objeto.Correo &&
                                                u.Clave == _utilidades.encriptarSHA256(objeto.Clave)).FirstOrDefaultAsync();
            if(usuarioEncontrado == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado) });
            }
        }
    }
}
