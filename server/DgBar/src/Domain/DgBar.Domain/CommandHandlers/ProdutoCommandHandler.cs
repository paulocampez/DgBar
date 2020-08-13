using DgBar.Domain.Commands;
using DgBar.Domain.Core.Bus;
using DgBar.Domain.Interfaces;
using DgBar.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DgBar.Domain.CommandHandlers
{
    public class ProdutoCommandHandler : CommandHandler, IRequestHandler<CadastrarNovoProdutoCommand, bool>
    {
        private readonly IBusHandler _bus;
        private readonly IProdutoRepository _repository;

        public ProdutoCommandHandler(IProdutoRepository repository, IUnitOfWork uow, IBusHandler bus) : base(uow, bus)
        {
            _bus = bus;
            _repository = repository;
        }

        public Task<bool> Handle(CadastrarNovoProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Id, request.Descricao, request.NumeroComanda, request.Valor, request.Quantidade, request.Desconto, request.Observacao);
            _repository.Add(produto);

            Commit();
            return Task.FromResult(true);
        }
    }
}
