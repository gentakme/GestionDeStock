using AutoMapper;
using GestionDeStock.Articles;
using GestionDeStock.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeStock.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>().ReverseMap()
                                            .ForMember(x => x.CategorieType, opt => opt.MapFrom(dto => Enum.Parse<CategorieType>(dto.CategorieType)));
            CreateMap<Article, CreateUpdateArticleDto>().ReverseMap();
        }
    }
}
