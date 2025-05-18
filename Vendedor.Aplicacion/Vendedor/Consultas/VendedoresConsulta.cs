

using MediatR;
using System.ComponentModel.DataAnnotations;
using Vendedor.Aplicacion.Vendedor.Dto;

namespace Vendedor.Aplicacion.Vendedor.Consultas
{
    public record VendedoresConsulta() : IRequest<ListaVendedoresOut>;
    public record VendedorPorIdConsulta(Guid Id) : IRequest<VendedorOut>;
    public record VendedorPorDocumentoConsulta(int IdTipoDocumento, string NumeroDocumento) : IRequest<VendedorOut>;
    public record ReporteVentasConsulta(
        [Required(ErrorMessage = "El campo Id es obligatorio")]
        Guid IdVendedor,
        [Required(ErrorMessage = "El campo FechaInicio es obligatorio")]
        DateOnly FechaInicio,
        [Required(ErrorMessage = "El campo FechaFin es obligatorio")]
        DateOnly FechaFin
        ) : IRequest<ReporteVendedorOut>;
}
