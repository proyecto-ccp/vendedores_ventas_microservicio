
using System.Diagnostics.CodeAnalysis;

namespace Vendedor.Dominio.ObjetoValor
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseObjetoValor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
