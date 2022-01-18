using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace GestionDeStock.EntityFrameworkCore
{
    [DependsOn(
        typeof(GestionDeStockEntityFrameworkCoreModule)
        )]
    public class GestionDeStockEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<GestionDeStockMigrationsDbContext>();
        }
    }
}
