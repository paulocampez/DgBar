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
using System.Threading.Tasks;
using Xunit;

namespace DgBar.Tests
{
    public class ProdutosTeste
    {
        ProdutoController _controller;
        public ProdutosTeste()
        {
            var fakeMediator = new Mock<IMediator>();
            var fakedResult = new TestResult(new TestCase());
            var mediator = new InMemoryBus(fakeMediator.Object);
            var produtoModel = new Produto(Guid.NewGuid(), "Cerveja");
            var produtoVM = new ProdutoViewModel();
            var mockRepo = new Mock<IProdutoRepository>();
            var mapperMock = new Mock<IMapper>();

            //implementar quando existir o metodo get no repositorio
            //mockRepo.Setup(repo => repo.GetAll()).Returns(Task.FromResult(GetAllTestProduto()).Result);
            mapperMock.Setup(m => m.Map<Produto, ProdutoViewModel>(produtoModel)).Returns(produtoVM);

            var service = new ProdutoApplicationService(mockRepo.Object, mediator, mapperMock.Object);
            _controller = new ProdutoController(service);
        }
        [Fact]
        public void Test1()
        {
            var result = _controller.GetAll();

            Assert.IsType<OkObjectResult>(result);
        }
        private IEnumerable<ProdutoViewModel> GetAllTestProduto()
        {
            List<ProdutoViewModel> produtoViewModels = new List<ProdutoViewModel>();
            var produto = new ProdutoViewModel();
            produtoViewModels.Add(produto);
            return produtoViewModels;
        }
    }
}
