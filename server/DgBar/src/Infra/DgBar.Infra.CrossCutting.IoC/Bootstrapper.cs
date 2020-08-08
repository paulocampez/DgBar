using DgBar.Application.Interfaces;
using DgBar.Application.Services;
using DgBar.Domain.CommandHandlers;
using DgBar.Domain.Commands;
using DgBar.Domain.Core.Bus;
using DgBar.Domain.Interfaces;
using DgBar.Infra.CrossCutting.Bus;
using DgBar.Infra.Data.Context;
using DgBar.Infra.Data.Repository;
using DgBar.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Infra.CrossCutting.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            // Mediatr
            service.AddScoped<IBusHandler, InMemoryBus>();
            // Application
            service.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
            // Domain 
            service.AddScoped<IRequestHandler<CadastrarNovoProdutoCommand, bool>, ProdutoCommandHandler>();
            // Infra 
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<DgBarContext>();
        }
    }
}
