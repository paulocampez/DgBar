using AutoMapper;
using DgBar.Application.ViewModels;
using DgBar.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, CadastrarNovoProdutoCommand>()
                .ConstructUsing(c => new CadastrarNovoProdutoCommand(c.Descricao));

            CreateMap<ComandaViewModel, CadastrarNovaComandaCommand>()
               .ConstructUsing(c => new CadastrarNovaComandaCommand(c.Produtos));
        }
    }
}
