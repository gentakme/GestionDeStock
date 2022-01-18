using System;
using System.Collections.Generic;
using System.Text;
using GestionDeStock.Localization;
using Volo.Abp.Application.Services;

namespace GestionDeStock
{
    /* Inherit your application services from this class.
     */
    public abstract class GestionDeStockAppService : ApplicationService
    {
        protected GestionDeStockAppService()
        {
            LocalizationResource = typeof(GestionDeStockResource);
        }
    }
}
