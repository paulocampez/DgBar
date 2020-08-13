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
        private readonly IProdutoRepository _repositoryProduto;

        public ComandaApplicationService(IComandaRepository repository, IBusHandler bus, IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
            _repositoryProduto = produtoRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public List<Produto> GetAllProdutos(int numeroComanda)
        {
            return _repository.GetAll().Where(p => p.NumeroComanda == numeroComanda).First().Produtos;
        }
        public ComandaViewModel FecharComanda(int numeroComanda)
        {
            int total = 0;
            int descontos = 0;
            var allComands = _repository.GetAll();
            var comandaModel = allComands.Where(p => p.NumeroComanda == numeroComanda).FirstOrDefault();

            var productsList = _repositoryProduto.GetAll().Where(p => p.NumeroComanda == numeroComanda).ToList();
            productsList = DesagrupaProdutos(productsList);
            productsList = AplicarPromocao(productsList);

            var comandaVMTeste = new ComandaViewModel() { Id = comandaModel.Id, NumeroComanda = comandaModel.NumeroComanda, Produtos = productsList };
            var fecharComandaCommand = _mapper.Map<FecharComandaCommand>(comandaVMTeste);
            _bus.SendCommand(fecharComandaCommand);
            productsList.ForEach(p => { total += (p.Valor) * (p.Quantidade); });
            productsList.ForEach(p => { descontos += (p.Desconto) * (p.Quantidade); });
            comandaVMTeste.Total = total;
            comandaVMTeste.Desconto = descontos;

            return comandaVMTeste;
            //return _mapper.Map<ComandaViewModel>(_repository.GetById(fecharComandaCommand.Id));
        }

        private List<Produto> DesagrupaProdutos(List<Produto> productsList)
        {
            List<Produto> newList = new List<Produto>();
            foreach (var item in productsList)
            {
                for (int i = 0; i < item.Quantidade; i++)
                {
                    newList.Add(new Produto(item.Id, item.Descricao, item.NumeroComanda, item.Valor, 1, item.Desconto, item.Observacao));
                }

            }
            return newList;
        }

        public ComandaViewModel AbrirComanda()
        {
            ComandaViewModel model = new ComandaViewModel() { };
            var registerCommand = _mapper.Map<CadastrarNovaComandaCommand>(model);
            _bus.SendCommand(registerCommand);
            return _mapper.Map<ComandaViewModel>(_repository.GetById(registerCommand.Id));
        }

        public bool RegistrarItens(IEnumerable<ProdutoViewModel> dto, int comanda)
        {
            bool success = true;
            success = ValidaProdutos(dto, comanda);

            if (success)
            {
                foreach (var produtoItem in dto)
                {
                    produtoItem.numeroComanda = comanda;
                    var registerCommand = _mapper.Map<CadastrarNovoProdutoCommand>(produtoItem);
                    _bus.SendCommand(registerCommand);
                }
            }
            return success;
        }

        private List<Produto> AplicarPromocao(List<Produto> dto)
        {
            #region Cerveja
            int cervejas = 0;
            int suco = 0;
            int conhaque = 0;
            int descontosDoConhaque = 0;
            foreach (var item in dto.Where(p => p.Descricao == "Cerveja").Select(p => p.Quantidade))
                cervejas += item;
            foreach (var sucos in dto.Where(p => p.Descricao == "Suco").Select(p => p.Quantidade))
                suco += sucos;

            int descontos = Math.Min(suco, cervejas);
            dto.Where(p => p.Descricao == "Cerveja").Take(descontos).ToList().ForEach(p => { p.Desconto = (p.Valor - 3); p.Valor = 3; p.Observacao = "Aplicado Desconto de R$" + p.Desconto; });
            #endregion

            #region AguaDeGracao
            foreach (var conhaques in dto.Where(p => p.Descricao == "Conhaque").Select(p => p.Quantidade))
                conhaque += conhaques;

            double descontoConhaque = conhaque / 3;
            int intervaloConhaque = Convert.ToInt32(Math.Floor(descontoConhaque));
            double descontoCerveja = cervejas / 2;
            int intervaloAgua = Convert.ToInt32(Math.Floor(descontoCerveja));

            if (intervaloConhaque > 0 && intervaloAgua > 0)
                descontosDoConhaque = Math.Min(intervaloConhaque, intervaloAgua);

            dto.Where(p => p.Descricao == "Água").Take(descontosDoConhaque).ToList().ForEach(p => { p.Desconto = (p.Valor - 0); p.Valor = 0; p.Observacao = "Ganhou a água"; });
            #endregion
            return dto;
        }

        private bool ValidaProdutos(IEnumerable<ProdutoViewModel> dto, int comanda)
        {
            var success = true;
            dto = DesagrupaProdutoViewModel(dto.ToList());

            var allProducts = _repositoryProduto.GetAll().Where(p => p.NumeroComanda == comanda).ToList();

            allProducts = DesagrupaProdutos(allProducts);

            int sucos = allProducts.Where(p => p.Descricao == "Suco").Count() + dto.Where(p => p.Descricao == "Suco").Count();

            if (sucos > 2)
                success = false;

            return success;
        }

        private List<ProdutoViewModel> DesagrupaProdutoViewModel(List<ProdutoViewModel> dto)
        {
            List<ProdutoViewModel> newList = new List<ProdutoViewModel>();
            foreach (var item in dto)
            {
                for (int i = 0; i < item.quantidade; i++)
                {
                    newList.Add(new ProdutoViewModel() { Id = item.Id, desconto = item.desconto, Descricao = item.Descricao, img = item.img, numeroComanda = item.numeroComanda, observacao = item.observacao, quantidade = 1, tipo = item.tipo, valor = item.valor });
                }

            }
            return newList;
        }

        public void ResetarComanda(int id)
        {
            var allProducts = _repositoryProduto.GetAll().Where(p => p.NumeroComanda == id).ToList();
            foreach (var item in allProducts)
            {
                _repositoryProduto.Delete(item);
            }
        }

        public IQueryable<Comanda> GetAllComandas()
        {
            return _repository.GetAll();
        }
    }
}
