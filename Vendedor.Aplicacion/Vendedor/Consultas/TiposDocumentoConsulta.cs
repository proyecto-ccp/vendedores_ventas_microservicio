
using MediatR;
using System.Diagnostics.CodeAnalysis;
using Vendedor.Aplicacion.Documento.Dto;

namespace Vendedor.Aplicacion.Vendedor.Consultas
{
    [ExcludeFromCodeCoverage]
    public record TiposDocumentoConsulta() : IRequest<ListaTipoDocumentosOut>;
    
}
