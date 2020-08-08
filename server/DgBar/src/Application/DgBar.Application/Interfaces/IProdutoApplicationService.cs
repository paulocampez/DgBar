using DgBar.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.Interfaces
{
    public interface IProdutoApplicationService : IDisposable
    {
        ProdutoViewModel Create(ProdutoViewModel produto);
    }
}
