using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GestionDeStock.Data
{
    /* This is used if database provider does't define
     * IGestionDeStockDbSchemaMigrator implementation.
     */
    public class NullGestionDeStockDbSchemaMigrator : IGestionDeStockDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}