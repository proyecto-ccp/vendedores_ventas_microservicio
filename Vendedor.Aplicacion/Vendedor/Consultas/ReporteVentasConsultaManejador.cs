
using AutoMapper;
using MediatR;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Dto;
using Vendedor.Dominio.Servicios.Vendedores;

namespace Vendedor.Aplicacion.Vendedor.Consultas
{
    public class ReporteVentasConsultaManejador : IRequestHandler<ReporteVentasConsulta, ReporteVendedorOut>
    {
        private readonly IMapper _mapper;
        private readonly ReporteVentas _servicioReporte;

        public ReporteVentasConsultaManejador(IMapper mapper, ReporteVentas servicioReporte)
        {
            _mapper = mapper;
            _servicioReporte = servicioReporte;
        }

        public async Task<ReporteVendedorOut> Handle(ReporteVentasConsulta request, CancellationToken cancellationToken)
        {
            ReporteVendedorOut output = new()
            {
                Detalle = []
            };

            try
            {
                var registrosReporte = await _servicioReporte.ObtenerReporte(request.IdVendedor, request.FechaInicio, request.FechaFin);

                if (registrosReporte.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No existen ventas para el vendedor";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Encabezado = _mapper.Map<Encabezado>(registrosReporte[0]);
                    registrosReporte.ForEach(detalleReporte => output.Detalle.Add(_mapper.Map<Detalle>(detalleReporte)));
                    output.Resultado = Resultado.Exitoso;
                    output.Mensaje = "Consulta exitosa";
                    output.Status = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = ex.Message;
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;
        }
    }
}
