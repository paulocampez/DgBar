using AutoMapper;
using DgBar.Application.ViewModels;
using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
