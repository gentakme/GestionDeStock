using GestionDeStock.Articles;
using GestionDeStock.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GestionDeStock.Application.Articles
{

    public class ArticleAppService : CrudAppService<Article, ArticleDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateArticleDto>
    {
        private readonly IRepository<Article, Guid> repository;

        public ArticleAppService(IRepository<Article, Guid> repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<PagedResultDto<ArticleDto>> GetByCategorie(CategorieType type)
        {
            var articles = repository.Where(x => x.CategorieType == type);
            var mappedModel = ObjectMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articles).AsQueryable();

            var totalCount = await AsyncExecuter.CountAsync(mappedModel);
            var entities = await AsyncExecuter.ToListAsync(mappedModel);

            return new PagedResultDto<ArticleDto>(totalCount, entities);

        }
    }
}
