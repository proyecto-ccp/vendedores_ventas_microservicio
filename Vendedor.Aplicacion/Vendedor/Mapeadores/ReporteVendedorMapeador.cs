
using AutoMapper;
using Vendedor.Aplicacion.Vendedor.Dto;

namespace Vendedor.Aplicacion.Vendedor.Mapeadores
{
    public class ReporteVendedorMapeador : Profile
    {
        public ReporteVendedorMapeador() 
        {
            CreateMap<Dominio.Entidades.ReporteVentas, ReporteVendedorDto>().ReverseMap();
            CreateMap<Dominio.Entidades.ReporteVentas, Encabezado>().ReverseMap();
            CreateMap<Dominio.Entidades.ReporteVentas, Detalle>().ReverseMap();

        }

    }
}
