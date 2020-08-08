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
        private readonly IBusHandler _bus;
        private readonly IProdutoRepository _repository;

        public ProdutoApplicationService(IProdutoRepository repository, IBusHandler bus, IMapper mapper)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
        }

        public ProdutoViewModel Create(ProdutoViewModel produtoViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarNovoProdutoCommand>(produtoViewModel);
            _bus.SendCommand(registerCommand);
            return _mapper.Map<ProdutoViewModel>(_repository.GetById(produtoViewModel.Id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
