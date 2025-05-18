
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Vendedor.Aplicacion.Comun;

namespace Vendedor.Aplicacion.Vendedor.Comandos
{
    [ExcludeFromCodeCoverage]
    public record VendedorCrear(

        [Required(ErrorMessage = "El campo IdTipoDcoumento es obligatorio")]
        int IdTipoDocumento,
        [Required(ErrorMessage = "El campo NumeroDocumento es obligatorio")]
        string NumeroDocumento,
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        string Nombre,
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        string Apellido,
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        [RegularExpression(@"\(\+\d{1,3}\) \d{3}-\d{3}-\d{4}",
        ErrorMessage = "El formato del teléfono no es válido. Ejemplo: (+1) 123-456-7890")]
        string Telefono,
        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        string Correo,
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        string Direccion,
        [Required(ErrorMessage = "El campo Idzona es obligatorio")]
        Guid? Idzona,
        [Required(ErrorMessage = "El campo Contrasena es obligatorio")]
        string Contrasena,
        [Required(ErrorMessage = "El campo IdUsuario es obligatorio")]
        Guid IdUsuario
        ) :IRequest<BaseOut>;
    
}
