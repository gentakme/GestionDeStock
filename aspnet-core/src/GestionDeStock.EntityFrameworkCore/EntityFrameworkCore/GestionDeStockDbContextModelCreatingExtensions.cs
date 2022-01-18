using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace GestionDeStock.EntityFrameworkCore
{
    public static class GestionDeStockDbContextModelCreatingExtensions
    {
        public static void ConfigureGestionDeStock(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.ConfigureArticle();
            builder.ConfigureCommande();
        }
    }
}