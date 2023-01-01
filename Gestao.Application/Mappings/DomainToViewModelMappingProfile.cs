using AutoMapper;
using Gestao.Application.ViewModels;
using Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                 .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Nome));
        }
    }
}
