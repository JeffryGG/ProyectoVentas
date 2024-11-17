using Entity;
using Microsoft.AspNetCore.Mvc;
using Bussiness;

namespace Api.Venta.Controllers
{
    [Route("Api/Rol")]
    public class RolController : ControllerBase
    {
        [Route("Registrar_Rol")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Registrar_Rol([FromBody] RolE objRol) 
        {
            try { 
                var resultado = await new RolBus().Registrar_Rol(objRol);
                if (resultado.IdRegistro == -1) 
                {
                    return BadRequest(resultado.Mensaje);
                }

                return Ok(resultado);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Actualizar_Rol")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Actualizar_Rol([FromBody] RolE objRol)
        {
            try
            {
                var resultado = await new RolBus().Actualizar_Rol(objRol);
                if (resultado.IdRegistro == -1)
                {
                    return BadRequest(resultado.Mensaje);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Eliminar_Rol")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Eliminar_Rol([FromBody] RolE objRol)
        {
            try
            {
                var resultado = await new RolBus().Eliminar_Rol(objRol);
                if (resultado.IdRegistro == -1)
                {
                    return BadRequest(resultado.Mensaje);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("Listar_X_ID")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Listar_X_ID(int orden, string buscar, int Idrol) 
        {
            try {
                var resultado = await new RolBus().Listar_X_ID(orden, buscar , Idrol);
                if (resultado.IdRegistro == -1) { 
                    return BadRequest(resultado.Mensaje);
                }
                return Ok(resultado);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Listar_All")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Listar_All(int orden, string buscar, int Idrol)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(buscar)) { buscar = ""; }
                var resultado = await new RolBus().Listar_All(orden, buscar, Idrol);
                if (resultado.IdRegistro == -1)
                {
                    return BadRequest(resultado.Mensaje);
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
