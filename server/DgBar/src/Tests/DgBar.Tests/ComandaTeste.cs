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
using System.Text;
using Xunit;

namespace DgBar.Tests
{
    
    public class ComandaTeste
    {
        ComandaController _controller;
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

            //implementar quando existir o metodo get no repositorio
            //mockRepo.Setup(repo => repo.GetAll()).Returns(Task.FromResult(GetAllTestProduto()).Result);
            //mapperMock.Setup(m => m.Map<Comanda, ComandaViewModel>(comandaModel)).Returns(comandaVM);

            var service = new ComandaApplicationService(mockRepo.Object, mediator, mapperMock.Object, mockRepoProduto.Object);
            _controller = new ComandaController(service);
        }

        [Fact]
        public void AbrirComandaTeste()
        {
            var result = _controller.AbrirComanda();

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
