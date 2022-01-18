using GestionDeStock.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GestionDeStock
{
    [DependsOn(
        typeof(GestionDeStockEntityFrameworkCoreTestModule)
        )]
    public class GestionDeStockDomainTestModule : AbpModule
    {

    }
}