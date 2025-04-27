
using AutoMapper;
using MediatR;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Vendedor.Dto;
using Vendedor.Dominio.Servicios.Vendedores;

namespace Vendedor.Aplicacion.Vendedor.Consultas
{
    public class VendedoresConsultaHandler : 
        IRequestHandler<VendedoresConsulta, ListaVendedoresOut>,
        IRequestHandler<VendedorPorIdConsulta, VendedorOut>,
        IRequestHandler<VendedorPorDocumentoConsulta, VendedorOut>
    {

        private readonly IMapper _mapper;
        private readonly Consultar _servicioConsultar;

        public VendedoresConsultaHandler(IMapper mapper, Consultar servicioConsultar)
        {
            _mapper = mapper;
            _servicioConsultar = servicioConsultar;
        }

        public async Task<ListaVendedoresOut> Handle(VendedoresConsulta request, CancellationToken cancellationToken)
        {
            ListaVendedoresOut output = new() 
            {
                Vendedores = []
            };

            try
            {
                var listaVendedores = await _servicioConsultar.Vendedores() ?? [];

                if (listaVendedores.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No existen vendedores";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    listaVendedores.ForEach(vendedor => output.Vendedores.Add(_mapper.Map<VendedorDto>(vendedor)));
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
        public async Task<VendedorOut> Handle(VendedorPorIdConsulta request, CancellationToken cancellationToken)
        {
            VendedorOut output = new();

            try
            {
                var vendedor = await _servicioConsultar.VendedorPorId(request.Id);

                if (vendedor is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No existen vendedor";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Vendedor = _mapper.Map<VendedorDto>(vendedor);
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
        public async Task<VendedorOut> Handle(VendedorPorDocumentoConsulta request, CancellationToken cancellationToken)
        {
            VendedorOut output = new();

            try
            {
                var vendedor = await _servicioConsultar.VendedorPorDocumento(request.IdTipoDocumento, request.NumeroDocumento);

                if (vendedor is null)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "No existen vendedor";
                    output.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    output.Vendedor = _mapper.Map<VendedorDto>(vendedor);
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
