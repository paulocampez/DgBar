using AutoMapper;
using DgBar.Application.Interfaces;
using DgBar.Application.ViewModels;
using DgBar.Domain.Commands;
using DgBar.Domain.Core.Bus;
using DgBar.Domain.Interfaces;
using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<Produto> GetAllProdutos(int numeroComanda)
        {
            return _repository.GetAll().Where(p => p.NumeroComanda == numeroComanda).First().Produtos;
        }
        public void FecharComanda(int numeroComanda)
        {
            var comandaModel = _repository.GetAll().Where(p=>p.NumeroComanda == numeroComanda).FirstOrDefault();
            var comandaVMTeste = new ComandaViewModel() { Id = comandaModel.Id, NumeroComanda = comandaModel.NumeroComanda, Produtos = comandaModel.Produtos};
            var fecharComandaCommand = _mapper.Map<FecharComandaCommand>(comandaVMTeste);
            _bus.SendCommand(fecharComandaCommand);
            //return _mapper.Map<ComandaViewModel>(_repository.GetById(fecharComandaCommand.Id));
        }

        public ComandaViewModel AbrirComanda()
        {
            ComandaViewModel model = new ComandaViewModel() { };
            var registerCommand = _mapper.Map<CadastrarNovaComandaCommand>(model);
            _bus.SendCommand(registerCommand);
            return _mapper.Map<ComandaViewModel>(_repository.GetById(registerCommand.Id));
        }

        public void RegistrarItens(IEnumerable<ProdutoViewModel> dto)
        {
            //Registrar pedido e fazer validacoes... retornar erro caso esteja adicionando 3 sucos
        }

        public void ResetarComanda(int id)
        {
            
        }
    }
}
