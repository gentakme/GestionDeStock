using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GestionDeStock.Commandes
{
    public class CommandeDto : EntityDto<Guid>
    {
        public Guid ArticleId { get; set; }
        public string ArticleName { get; set; }
        public DateTime DateCommande { get; set; }
    }
}
