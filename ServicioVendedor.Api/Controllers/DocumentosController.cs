using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Documento.Dto;
using Vendedor.Aplicacion.Vendedor.Consultas;

namespace ServicioVendedor.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar los tipos de documento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class DocumentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// constructor
        /// </summary>
        public DocumentosController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene la lista los tipos de documento
        /// </summary>
        /// <response code="200"> 
        /// ListaTipoDocumentosOut pendiente
        /// </response>
        [HttpGet]
        [Route("TiposDocumento")]
        [ProducesResponseType(typeof(ListaTipoDocumentosOut), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> ListarTiposDocumento()
        {
            var output = await _mediator.Send(new TiposDocumentoConsulta());

            if (output.Resultado != Resultado.Error)
            {
                return Ok(output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }
    }
}
