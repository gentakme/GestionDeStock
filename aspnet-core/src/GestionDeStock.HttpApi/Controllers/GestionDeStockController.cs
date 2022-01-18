using GestionDeStock.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GestionDeStock.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class GestionDeStockController : AbpController
    {
        protected GestionDeStockController()
        {
            LocalizationResource = typeof(GestionDeStockResource);
        }
    }
}