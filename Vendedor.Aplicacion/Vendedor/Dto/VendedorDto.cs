
using System.Diagnostics.CodeAnalysis;
using Vendedor.Aplicacion.Comun;

namespace Vendedor.Aplicacion.Vendedor.Dto
{
    [ExcludeFromCodeCoverage]
    public class VendedorDto
    {
        public int idTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class VendedorOut : BaseOut
    {
        public VendedorDto Vendedor { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ListaVendedoresOut : BaseOut
    {
        public List<VendedorDto> Vendedores { get; set; }
    }
}
