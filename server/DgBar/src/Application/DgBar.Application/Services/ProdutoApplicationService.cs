using DgBar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgBar.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
