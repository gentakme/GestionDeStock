using Volo.Abp.Modularity;

namespace GestionDeStock
{
    [DependsOn(
        typeof(GestionDeStockApplicationModule),
        typeof(GestionDeStockDomainTestModule)
        )]
    public class GestionDeStockApplicationTestModule : AbpModule
    {

    }
}