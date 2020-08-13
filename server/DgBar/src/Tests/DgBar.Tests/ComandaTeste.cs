using AutoMapper;
using DgBar.Application.Services;
using DgBar.Application.ViewModels;
using DgBar.Domain.Interfaces;
using DgBar.Domain.Models;
using DgBar.Infra.CrossCutting.Bus;
using DgBar.Services.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DgBar.Tests
{

    public class ComandaTeste
    {
        ComandaController _controller;
        ComandaApplicationService _comandaApplicationService;
        public ComandaTeste()
        {
            var fakeMediator = new Mock<IMediator>();
            var fakedResult = new TestResult(new TestCase());
            var mediator = new InMemoryBus(fakeMediator.Object);
            //var comandaModel = new Comanda(Guid.NewGuid(), );
            var comandaVM = new ComandaViewModel();
            var mockRepo = new Mock<IComandaRepository>();
            var mockRepoProduto = new Mock<IProdutoRepository>();
            var mapperMock = new Mock<IMapper>();

            // implementar quando existir o metodo get no repositorio
            //mockRepo.Setup(repo => repo.GetById()).Returns(Task.FromResult(GetComandaTeste()).Result);
            //mapperMock.Setup(m => m.Map<Comanda, ComandaViewModel>(comandaModel)).Returns(comandaVM);

            _comandaApplicationService = new ComandaApplicationService(mockRepo.Object, mediator, mapperMock.Object, mockRepoProduto.Object);
            _controller = new ComandaController(_comandaApplicationService);
        }

        [Fact]
        public void TesteGeralPromocao()
        {
            List<Produto> lstProdutos = new List<Produto>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Água");
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Suco");
            lstDescricao.Add("Conhaque");
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[rnd.Next(lstDescricao.Count)], rnd.Next(1,99), rnd.Next(1, 99), rnd.Next(1, 10), 0, ""));
            }

            var result = _comandaApplicationService.AplicarPromocao(lstProdutos);

            Assert.NotNull(result);
        }

        [Fact]
        public void TesteDescontoNaCerveja()
        {
            List<Produto> lstProdutos = new List<Produto>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Suco");
            Random rnd = new Random();

            for (int i = 0; i < 6; i++)
            {
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[0], rnd.Next(1, 99), 5, rnd.Next(1, 10), 0, ""));
            }
            for (int i = 0; i < rnd.Next(1, 6); i++)
            {
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[1], rnd.Next(1, 99), 50, rnd.Next(1, 10), 0, ""));
            }
            var result = _comandaApplicationService.AplicarPromocao(lstProdutos);

            Assert.True(result.ToList().Where(p=>p.Descricao == "Cerveja" && p.Valor == 3).Any());
        }

        [Fact]
        public void TesteDescontoNaAgua()
        {
            List<Produto> lstProdutos = new List<Produto>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Conhaque");
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Água");
            Random rnd = new Random();

            for (int i = 0; i < rnd.Next(10, 50); i++)
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[0], rnd.Next(1, 99), rnd.Next(1, 99), 1, 0, ""));
            for (int i = 0; i < rnd.Next(10, 50); i++)
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[1], rnd.Next(1, 99), rnd.Next(1, 99), 1, 0, ""));
            for (int i = 0; i < rnd.Next(3, 10); i++)
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[2], rnd.Next(1, 99), rnd.Next(1, 99), 1, 0, ""));
            var result = _comandaApplicationService.AplicarPromocao(lstProdutos);

            Assert.True(result.ToList().Where(p => p.Descricao == "Água" && p.Valor == 0).Any());
        }

        [Fact]
        public void TesteDesagruparListaProdutoDeveQuantidadeIgualAUm()
        {
            List<Produto> lstProdutos = new List<Produto>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Água");
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Suco");
            lstDescricao.Add("Conhaque");
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[rnd.Next(lstDescricao.Count)], rnd.Next(1, 99), rnd.Next(1, 99), rnd.Next(1, 10), 0, ""));
            }


            var result = _comandaApplicationService.DesagrupaProdutos(lstProdutos);

            Assert.False(result.ToList().Any(p=> p.Quantidade > 1));
        }

        [Fact]
        public void TesteDesagruparListaProdutoViewModelDeveQuantidadeIgualAUm()
        {
            List<ProdutoViewModel> lstProdutos = new List<ProdutoViewModel>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Água");
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Suco");
            lstDescricao.Add("Conhaque");
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                lstProdutos.Add(new ProdutoViewModel() { Id = Guid.NewGuid(), Descricao = lstDescricao[rnd.Next(lstDescricao.Count)], numeroComanda = rnd.Next(1, 99), valor = rnd.Next(1, 99), quantidade = rnd.Next(1, 10),desconto =  0, observacao = "" });
            }


            var result = _comandaApplicationService.DesagrupaProdutoViewModel(lstProdutos);

            Assert.False(result.ToList().Any(p => p.quantidade > 1));
        }

        [Fact]
        public void ApenasUmaCervejaDeveTerDesconto()
        {
            List<Produto> lstProdutos = new List<Produto>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Suco");
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[0], rnd.Next(1, 99), 5, 1, 0, ""));
            }
            for (int i = 0; i < 1; i++)
            {
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[1], rnd.Next(1, 99), 50, 1, 0, ""));
            }
            var result = _comandaApplicationService.AplicarPromocao(lstProdutos);

            Assert.True(result.ToList().Where(p => p.Descricao == "Cerveja" && p.Valor == 3).Count() == 1);
        }

        [Fact]
        public void ApenasUmaAguaDeveSerDeGraca()
        {
            List<Produto> lstProdutos = new List<Produto>();
            List<string> lstDescricao = new List<string>();
            lstDescricao.Add("Conhaque");
            lstDescricao.Add("Cerveja");
            lstDescricao.Add("Água");
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[0], rnd.Next(1, 99), rnd.Next(1, 99), 1, 0, ""));
            for (int i = 0; i < 20; i++)
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[1], rnd.Next(1, 99), rnd.Next(1, 99), 1, 0, ""));
            for (int i = 0; i < rnd.Next(3, 10); i++)
                lstProdutos.Add(new Produto(Guid.NewGuid(), lstDescricao[2], rnd.Next(1, 99), rnd.Next(1, 99), 1, 0, ""));
            var result = _comandaApplicationService.AplicarPromocao(lstProdutos);

            Assert.True(result.ToList().Where(p => p.Descricao == "Água" && p.Valor == 0).Count() == 1);
        }

    }
}
