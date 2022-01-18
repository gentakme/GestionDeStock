using GestionDeStock.Articles;
using GestionDeStock.Commandes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace GestionDeStock.EntityFrameworkCore
{
    public static class GestionDeStockDbContextCommandeExt
    {

        public static void ConfigureCommande(this ModelBuilder builder)
        {
            builder.Entity<Commande>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Commandes");
                b.HasOne<Article>().WithMany().HasForeignKey(f => f.ArticleId).OnDelete(DeleteBehavior.NoAction);
                b.ConfigureByConvention();

            });
        }
    }
}
