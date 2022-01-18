using GestionDeStock.Articles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace GestionDeStock.EntityFrameworkCore
{
    public static class GestionDeStockDbContextArticleExt
    {
        public static void ConfigureArticle(this ModelBuilder builder)
        {

            builder.Entity<Article>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Articles");
                b.Property(e=> e.CategorieType)
                    .HasConversion<string>();
                b.ConfigureByConvention();

            });
        }
    }
}
