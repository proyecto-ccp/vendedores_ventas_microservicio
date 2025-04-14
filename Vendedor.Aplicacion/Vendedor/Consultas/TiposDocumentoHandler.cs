
using AutoMapper;
using MediatR;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Aplicacion.Documento.Dto;
using Vendedor.Dominio.Servicios.Documentos;

namespace Vendedor.Aplicacion.Vendedor.Consultas
{
    public class TiposDocumentoHandler : IRequestHandler<TiposDocumentoConsulta, ListaTipoDocumentosOut>
    {
        private readonly IMapper _mapper;
        private readonly Listar _listarDocumentos;

        public TiposDocumentoHandler(Listar listarDocumentos, IMapper mapper) 
        {
            _listarDocumentos = listarDocumentos;
            _mapper = mapper;
        }

        public async Task<ListaTipoDocumentosOut> Handle(TiposDocumentoConsulta request, CancellationToken cancellationToken)
        {
            ListaTipoDocumentosOut output = new()
            {
                Documentos = []
            };

            try
            {
                var tiposDocumento = await _listarDocumentos.Ejecutar() ?? [];

                if (tiposDocumento.Count == 0)
                {
                    output.Resultado = Resultado.SinRegistros;
                    output.Mensaje = "Tipos de documento no tiene valores";
                    output.Status = HttpStatusCode.NoContent;
                }
                else
                {
                    tiposDocumento.ForEach(documento => output.Documentos.Add(_mapper.Map<TipoDocumentosDto>(documento)));
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
