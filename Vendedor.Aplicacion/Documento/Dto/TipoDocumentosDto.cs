
using System.Diagnostics.CodeAnalysis;
using Vendedor.Aplicacion.Comun;

namespace Vendedor.Aplicacion.Documento.Dto
{
    [ExcludeFromCodeCoverage]
    public class TipoDocumentosDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TipoDocumentoOut : BaseOut
    {
        public TipoDocumentosDto Documento { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaTipoDocumentosOut : BaseOut
    {
        public List<TipoDocumentosDto> Documentos { get; set; }
    }
}
