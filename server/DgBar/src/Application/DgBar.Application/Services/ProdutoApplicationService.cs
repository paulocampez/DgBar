using AutoMapper;
using DgBar.Application.Interfaces;
using DgBar.Application.ViewModels;
using DgBar.Domain.Commands;
using DgBar.Domain.Core.Bus;
using DgBar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IBusHandler Bus;
        private readonly IProdutoRepository _repository;

        public ProdutoViewModel Create()
        {
            var produtoViewModel = new ProdutoViewModel();
            var registerCommand = _mapper.Map<CadastrarNovoProdutoCommand>(produtoViewModel);
            Bus.SendCommand(registerCommand);
            return _mapper.Map<ProdutoViewModel>(_repository.GetById(produtoViewModel.Id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
