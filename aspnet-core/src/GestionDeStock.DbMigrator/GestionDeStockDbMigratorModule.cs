using GestionDeStock.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace GestionDeStock.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(GestionDeStockEntityFrameworkCoreDbMigrationsModule),
        typeof(GestionDeStockApplicationContractsModule)
        )]
    public class GestionDeStockDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
