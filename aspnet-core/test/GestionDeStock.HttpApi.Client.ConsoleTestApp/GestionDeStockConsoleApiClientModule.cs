using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace GestionDeStock.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(GestionDeStockHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class GestionDeStockConsoleApiClientModule : AbpModule
    {
        
    }
}
