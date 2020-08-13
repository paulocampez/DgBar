using DgBar.Domain.Commands;
using DgBar.Domain.Core.Bus;
using DgBar.Domain.Interfaces;
using DgBar.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DgBar.Domain.CommandHandlers
{
    public class RegistrarPedidoCommandHandler : CommandHandler, IRequestHandler<RegistrarPedidoCommand, bool>
    {
        private readonly IBusHandler _bus;
        private readonly IComandaRepository _repository;
        private readonly IProdutoRepository _repositoryP;

        public RegistrarPedidoCommandHandler(IComandaRepository repository, IUnitOfWork uow, IBusHandler bus) : base(uow, bus)
        {
            _bus = bus;
            _repository = repository;
        }

        public Task<bool> Handle(RegistrarPedidoCommand request, CancellationToken cancellationToken)
        {
            var comanda = new Comanda(request.Id, request.NumeroComanda);
            _repository.Add(comanda);
            Commit();
            return Task.FromResult(true);
        }
    }
}
