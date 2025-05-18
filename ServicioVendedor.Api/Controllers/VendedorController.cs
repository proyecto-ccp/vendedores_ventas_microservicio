using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Comandos;
using Vendedor.Aplicacion.Vendedor.Consultas;
using Vendedor.Aplicacion.Vendedor.Dto;

namespace ServicioVendedor.Api.Controllers
{
    /// <summary>
    /// Controlador de vendedores
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class VendedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor del controlador
        /// </summary>
        public VendedorController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea un vendedor nuevo 
        /// </summary>
        /// <response code="201"> 
        /// BaseOut: objeto de salida <br/>
        /// Resultado: Enumerador de la operación, Exitoso = 1, Error = 2, SinRegistros = 3 <br/>
        /// Mensaje: Mensaje de la operación <br/>
        /// Status: Código de estado HTTP <br/>
        /// </response>
        [HttpPost]
        [Route("Crear")]
        [ProducesResponseType(typeof(BaseOut), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 401)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 500)]
        public async Task<IActionResult> Crear([FromBody] VendedorCrear producto)
        {
            var output = await _mediator.Send(producto);

            if (output.Resultado != Resultado.Error)
            {
                return Created(string.Empty, output);
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene la lista del atributo de producto categorias
        /// </summary>
        /// <response code="200"> 
        /// </response>
        [HttpGet]
        [Route("Consultar")]
        [ProducesResponseType(typeof(ListaVendedoresOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Consultar()
        {
            var output = await _mediator.Send(new VendedoresConsulta());

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene un vendedor por su Identificador
        /// </summary>
        /// <response code="200"> 
        /// </response>
        [HttpGet]
        [Route("{IdVendedor}")]
        [ProducesResponseType(typeof(VendedorOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ConsultarPorId(Guid IdVendedor)
        {
            var output = await _mediator.Send(new VendedorPorIdConsulta(IdVendedor));

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene un vendedor por su Identificador
        /// </summary>
        /// <response code="200"> 
        /// </response>
        [HttpGet]
        [Route("TipoDocumento/{IdTipoDocumento}/Documento/{Documento}")]
        [ProducesResponseType(typeof(VendedorOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ConsultarPorId([FromRoute] int IdTipoDocumento, string Documento)
        {
            var output = await _mediator.Send(new VendedorPorDocumentoConsulta(IdTipoDocumento, Documento));

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }

        /// <summary>
        /// Obtiene un reporte de ventas por vendedor en un rango de fechas
        /// </summary>
        /// <response code="200"> 
        /// </response>
        [HttpPost]
        [Route("ReporteVentas")]
        [ProducesResponseType(typeof(ReporteVendedorOut), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 401)]
        [ProducesResponseType(typeof(BaseOut), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> ReporteVentas([FromBody] ReporteVentasConsulta input)
        {
            var output = await _mediator.Send(input);

            if (output.Resultado == Resultado.Exitoso)
            {
                return Ok(output);
            }
            else if (output.Resultado == Resultado.SinRegistros)
            {
                return NotFound(new { output.Resultado, output.Mensaje, output.Status });
            }
            else
            {
                return Problem(output.Mensaje, statusCode: (int)output.Status);
            }
        }



    }
}
