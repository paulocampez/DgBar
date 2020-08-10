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
        public IEnumerable<ProdutoViewModel> GetAll()
        {
            List<ProdutoViewModel> produtos = new List<ProdutoViewModel>();
            produtos.Add(new ProdutoViewModel() { Id = Guid.NewGuid(), Descricao = "Cerveja", img = "/img/cerveja.jpg", tipo = "Bebida", valor = 5 });
            produtos.Add(new ProdutoViewModel() { Id = Guid.NewGuid(), Descricao = "Conhaque", img = "/img/conhaque.jpg", tipo = "Bebida", valor = 20 });
            produtos.Add(new ProdutoViewModel() { Id = Guid.NewGuid(), Descricao = "Suco", img = "/img/suco.jpg", tipo = "Bebida", valor = 50 });
            produtos.Add(new ProdutoViewModel() { Id = Guid.NewGuid(), Descricao = "Água", img = "/img/agua.jpg", tipo = "Bebida", valor = 70 });
            return produtos;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
