﻿using DgBar.Application.ViewModels;
using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.Interfaces
{
    public interface IComandaApplicationService : IDisposable
    {
        void ResetarComanda(int id);
        void RegistrarItens(IEnumerable<ProdutoViewModel> dtos);
        void FecharComanda(int id);
        ComandaViewModel AbrirComanda();
        List<Produto> GetAllProdutos(int numeroComanda);
    }
}
