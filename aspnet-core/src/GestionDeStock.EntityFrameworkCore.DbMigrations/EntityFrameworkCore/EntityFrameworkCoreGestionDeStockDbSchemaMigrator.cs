using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestionDeStock.Data;
using Volo.Abp.DependencyInjection;

namespace GestionDeStock.EntityFrameworkCore
{
    public class EntityFrameworkCoreGestionDeStockDbSchemaMigrator
        : IGestionDeStockDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreGestionDeStockDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the GestionDeStockMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<GestionDeStockMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}