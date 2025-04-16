
using System.Diagnostics.CodeAnalysis;

namespace Vendedor.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class EntidadBaseGuid
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
