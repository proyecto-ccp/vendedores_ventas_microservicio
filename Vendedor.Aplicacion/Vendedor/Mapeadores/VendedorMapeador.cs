
using AutoMapper;
using Vendedor.Aplicacion.Vendedor.Comandos;
using Vendedor.Aplicacion.Vendedor.Dto;

namespace Vendedor.Aplicacion.Vendedor.Mapeadores
{
    public class VendedorMapeador : Profile
    {
        public VendedorMapeador() 
        {
            CreateMap<Dominio.Entidades.Vendedor, VendedorDto>().ReverseMap();
            CreateMap<VendedorCrear, Dominio.Entidades.Vendedor>().ReverseMap();
        }
    }
}
