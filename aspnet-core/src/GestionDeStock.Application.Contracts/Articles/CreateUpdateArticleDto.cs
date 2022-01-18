using GestionDeStock.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeStock.Articles
{
    public class CreateUpdateArticleDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategorieType { get; set; }
    }
}
