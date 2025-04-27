

using System.Linq.Expressions;

namespace Vendedor.Infraestructura.Adaptadores.RepositorioGenerico
{
    public interface IRepositorioBase<T> : IDisposable where T : class
    {
        Task<T> Guardar(T entity);
        Task<T> BuscarPorLlave(object ValueKey);
        Task<List<T>> DarListado();
        Task<T> BuscarPorCampos(Expression<Func<T, bool>> expr);
        Task<List<T>> DarListadoPorCampos(Expression<Func<T, bool>> expr);
    }
}
