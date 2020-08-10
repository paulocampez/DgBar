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
    public class ComandaApplicationService : IComandaApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IBusHandler _bus;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IComandaRepository _repository;

        public ComandaApplicationService(IComandaRepository repository, IBusHandler bus, IMapper mapper)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void FecharComanda(int id)
        {
            
        }

        public ComandaViewModel AbrirComanda()
        {
            ComandaViewModel model = new ComandaViewModel() { };
            var registerCommand = _mapper.Map<CadastrarNovaComandaCommand>(model);
            _bus.SendCommand(registerCommand);
            return _mapper.Map<ComandaViewModel>(_repository.GetById(registerCommand.Id));
        }

        public void RegistrarItem(RegistrarPedidosViewModel dto)
        {
            
        }

        public void ResetarComanda(int id)
        {
            
        }
    }
}
