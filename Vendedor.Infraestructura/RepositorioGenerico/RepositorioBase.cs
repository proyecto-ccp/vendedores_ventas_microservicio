﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Productos.Infraestructura.Adaptadores.Repositorios;
using System.Diagnostics.CodeAnalysis;

namespace Vendedor.Infraestructura.Adaptadores.RepositorioGenerico
{
    [ExcludeFromCodeCoverage]
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositorioBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        private VendedoresDbContext GetContext()
        {
            return _serviceProvider.GetService<VendedoresDbContext>();
        }

        protected DbSet<T> GetEntitySet()
        {
            return GetContext().Set<T>();
        }
        public async Task<T> BuscarPorLlave(object ValueKey)
        {
            var ctx = GetContext();
            var entitySet = ctx.Set<T>();
            var res = await entitySet.FindAsync(ValueKey);
            await ctx.DisposeAsync();
            return res;
        }

        public async Task<List<T>> DarListado()
        {
            var ctx = GetContext();
            var entitySet = ctx.Set<T>();
            var res = await entitySet.ToListAsync();
            await ctx.DisposeAsync();
            return res;
        }

        public async Task<T> Guardar(T entity)
        {
            var ctx = GetContext();
            var entitySet = ctx.Set<T>();
            var res = await entitySet.AddAsync(entity);
            await ctx.SaveChangesAsync();
            await ctx.DisposeAsync();
            return res.Entity;
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                try
                {
                    var ctx = GetContext();
                    ctx.Dispose();
                }
                catch (Exception)
                { }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
