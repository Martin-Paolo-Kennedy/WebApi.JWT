using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.JWT.Custom;
using WebApi.JWT.Models;
using WebApi.JWT.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.JWT.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly BdJwtContext _bdJwtContext;
        public ProductoController(BdJwtContext bdJwtContext)
        {
            _bdJwtContext = bdJwtContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var lista = await _bdJwtContext.TbProductos.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = lista });
        }

        
    }
}
