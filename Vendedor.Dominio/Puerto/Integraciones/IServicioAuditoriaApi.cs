using Vendedor.Dominio.ObjetoValor;

namespace Vendedor.Dominio.Puertos.Integraciones
{
    public interface IServicioAuditoriaApi
    {
        Task RegistrarAuditoria(Auditoria auditoria);
    }
}
