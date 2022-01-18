using GestionDeStock.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GestionDeStock.Articles
{
    public class ArticleDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategorieType { get; set; }
    }
}
