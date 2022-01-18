using AutoMapper;
using GestionDeStock.Commandes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeStock.Profiles
{
    public class CommandeProfile : Profile
    {
        public CommandeProfile()
        {
            CreateMap<Commande, CommandeDto>().ReverseMap();
            CreateMap<Commande, CreateUpdateCommandeDto>().ReverseMap();

        }
    }
}
