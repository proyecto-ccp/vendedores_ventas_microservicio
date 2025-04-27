
using System.Diagnostics.CodeAnalysis;

namespace Vendedor.Dominio.Entidades
{
    [ExcludeFromCodeCoverage]
    public class Vendedor : EntidadBaseGuid
    {
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public Guid Idzona { get; set; }

    }
}
