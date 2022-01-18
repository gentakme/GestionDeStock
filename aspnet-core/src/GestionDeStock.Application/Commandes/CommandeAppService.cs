using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using GestionDeStock.Articles;
using Volo.Abp;
using Microsoft.EntityFrameworkCore;

namespace GestionDeStock.Commandes
{
    public class CommandeAppService : CrudAppService<Commande, CommandeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCommandeDto>
    {
        private readonly IRepository<Commande, Guid> CommandeRepository;
        private readonly IRepository<Article, Guid> ArticlesRepository;

        public CommandeAppService(IRepository<Commande, Guid> commandeRepository,
            IRepository<Article, Guid> articlesRepository) : base(commandeRepository)
        {
            this.CommandeRepository = commandeRepository;
            this.ArticlesRepository = articlesRepository;
        }

        public override async Task<CommandeDto> GetAsync(Guid id)
        {
            var query = CommandeRepository.AsQueryable();
            var listCommande = await query.Join(ArticlesRepository, c => c.ArticleId, a => a.Id, (cmd, art) => new { cmd, art })
                                    .Select(x => new CommandeDto
                                    {
                                        ArticleId = x.art.Id,
                                        ArticleName = x.art.Name,
                                        DateCommande = x.cmd.DateCommande,
                                        Id = x.cmd.Id
                                      
                                    }).FirstOrDefaultAsync();

            return listCommande;
        }

        public override async Task<PagedResultDto<CommandeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = CommandeRepository.AsQueryable();
            var listCommande = query.Join(ArticlesRepository, c => c.ArticleId, a => a.Id, (cmd, art) => new { cmd, art })
                                    .Select(x => new CommandeDto
                                    {
                                        ArticleId = x.art.Id,
                                        ArticleName = x.art.Name,
                                        DateCommande = x.cmd.DateCommande,
                                        Id = x.cmd.Id
                                    });

            var totalCount = await AsyncExecuter.CountAsync(listCommande);
            var entities = await AsyncExecuter.ToListAsync(listCommande);

            return new PagedResultDto<CommandeDto>(totalCount, entities);
        }

        public override async Task<CommandeDto> CreateAsync(CreateUpdateCommandeDto input)
        {
            var article = await GetArticle(input.ArticleId);

            article.Quantity -= 1;
            await ArticlesRepository.UpdateAsync(article, true);

            var entity = await CommandeRepository.InsertAsync(new Commande { ArticleId = input.ArticleId, DateCommande = DateTime.Now }, true);

            return ObjectMapper.Map<Commande, CommandeDto>(entity);
        }

        public override async Task<CommandeDto> UpdateAsync(Guid id, CreateUpdateCommandeDto input)
        {
            var commande = await CommandeRepository.FindAsync(x => x.Id == id);
            if (commande == null)
            {
                throw new UserFriendlyException("Commande was not found!");
            }

            var article = await GetArticle(input.ArticleId);

            article.Quantity -= 1;
            await ArticlesRepository.UpdateAsync(article, true);

            commande.ArticleId = input.ArticleId;
            var entity = await CommandeRepository.UpdateAsync(commande, true);

            return ObjectMapper.Map<Commande, CommandeDto>(entity);
        }

        private async Task<Article> GetArticle(Guid articleId)
        {
            var article = await ArticlesRepository.FindAsync(x => x.Id == articleId);
            if (article == null || article.Quantity < 1)
            {
                throw new UserFriendlyException("Article is out of stock!");
            }
            return article;
        }
    }
}
