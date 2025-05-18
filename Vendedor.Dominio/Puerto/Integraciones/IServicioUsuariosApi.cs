
using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Dominio.Puerto.Integraciones
{
    public interface IServicioUsuariosApi
    {
        Task<UsuarioOut> CrearUsuario(UsuarioIn usuario);
    }
}
