
using AutoMapper;
using Vendedor.Aplicacion.Vendedor.Comandos;
using Vendedor.Aplicacion.Vendedor.Dto;
using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Aplicacion.Vendedor.Mapeadores
{
    public class VendedorMapeador : Profile
    {
        public VendedorMapeador() 
        {
            CreateMap<Dominio.Entidades.Vendedor, VendedorDto>().ReverseMap();
            CreateMap<VendedorCrear, Dominio.Entidades.Vendedor>().ReverseMap();

            CreateMap<VendedorCrear, Auditoria>()
                .ForMember(dest => dest.IdUsuario, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Accion, opt => opt.MapFrom(src => "Vendedor creado"))
                .ForMember(dest => dest.TablaAfectada, opt => opt.MapFrom(src => "tbl_vendedor"));

            CreateMap<VendedorCrear, UsuarioIn>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Contrasena, opt => opt.MapFrom(src => src.Contrasena))
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => "1f4e05fb-775d-432e-b474-a521eda899fd"));
        }
    }
}
