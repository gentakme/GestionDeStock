using GestionDeStock.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace GestionDeStock.Articles
{
   public class Article : Entity<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int  Quantity { get; set; }
        public CategorieType CategorieType { get; set; }
    }
}
