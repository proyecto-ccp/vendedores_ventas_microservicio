
using AutoMapper;
using Vendedor.Aplicacion.Documento.Dto;

namespace Vendedor.Aplicacion.Documento.Mapeadores
{
    public class TipoDocumentosMapeador : Profile     
    {
        public TipoDocumentosMapeador() 
        {
            CreateMap<Dominio.ObjetoValor.Documento, TipoDocumentosDto>().ReverseMap();

        }
    }
}
