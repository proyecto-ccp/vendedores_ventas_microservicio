

using MediatR;
using Vendedor.Aplicacion.Vendedor.Dto;

namespace Vendedor.Aplicacion.Vendedor.Consultas
{
    public record VendedoresConsulta() : IRequest<ListaVendedoresOut>;
    public record VendedorPorIdConsulta(Guid Id) : IRequest<VendedorOut>;
    public record VendedorPorDocumentoConsulta(int IdTipoDocumento, string NumeroDocumento) : IRequest<VendedorOut>;
}
