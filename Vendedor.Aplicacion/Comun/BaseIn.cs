
using System.Diagnostics.CodeAnalysis;

namespace Vendedor.Aplicacion.Comun
{
    [ExcludeFromCodeCoverage]
    public class BaseIn
    {
        public string Token {get; set; }
        public string IdUsuario { get; set; }
    }
}
