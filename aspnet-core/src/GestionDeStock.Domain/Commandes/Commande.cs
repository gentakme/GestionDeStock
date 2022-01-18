using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace GestionDeStock.Commandes
{
    public class Commande : AuditedEntity<Guid>
    {
        public Guid ArticleId { get; set; }
        public DateTime DateCommande { get; set; }
     }
}
