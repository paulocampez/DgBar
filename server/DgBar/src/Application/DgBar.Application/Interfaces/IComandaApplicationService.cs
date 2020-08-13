using DgBar.Application.ViewModels;
using DgBar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DgBar.Application.Interfaces
{
    public interface IComandaApplicationService : IDisposable
    {
        void ResetarComanda(int id);
        bool RegistrarItens(IEnumerable<ProdutoViewModel> dtos, int comanda);
        ComandaViewModel FecharComanda(int id);
        ComandaViewModel AbrirComanda();
        List<Produto> GetAllProdutos(int numeroComanda);
        IQueryable<Comanda> GetAllComandas();
    }
}
