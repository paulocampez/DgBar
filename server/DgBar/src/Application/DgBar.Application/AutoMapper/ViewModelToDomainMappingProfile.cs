﻿using AutoMapper;
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
                .ConstructUsing(c => new CadastrarNovoProdutoCommand(c.Descricao, c.valor, c.quantidade, c.desconto, c.observacao));

            CreateMap<ComandaViewModel, CadastrarNovaComandaCommand>()
               .ConstructUsing(c => new CadastrarNovaComandaCommand(c.Produtos));

            CreateMap<ComandaViewModel, FecharComandaCommand>()
                .ConstructUsing(c => new FecharComandaCommand(c.Produtos));

            CreateMap<ComandaViewModel, RegistrarPedidoCommand>()
                .ConstructUsing(c => new RegistrarPedidoCommand(c.Produtos));
        }
    }
}
